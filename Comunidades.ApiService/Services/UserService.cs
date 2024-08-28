using Azure.Core;
using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Models.Responses;
using Comunidades.ApiService.Repositories.Interfaces;
using Comunidades.ApiService.Services.Helpers;
using Comunidades.ApiService.Services.Interfaces;
using Comunidades.ApiService.Services.Validations;
using Comunidades.ApiService.Shared;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.ApiService.Services
{
    /// <summary>
    /// Representa o serviço responsável pelo conexão com os dados do usuário.
    /// </summary>
    public class UserService : BaseService, IUserService
    {
        readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Cria um novo usuário no banco.
        /// </summary>
        public async Task<IServiceResult> CreateAsync(UserCreatePostRequest request)
        {
            request.Sanitize();

            //Validações
            var result = ValidatorHelper.Validate<UserCreatePostValidation, UserCreatePostRequest>(request);

            if (!result.IsValid)
                return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);
            
            var password = Password.GetPasswordHash(request.Password!);
            var dateNow = DateTime.Now;
            
            var entity = new UserEntity
            {
                FullName = request.FullName!,
                UserName = request.UserName!,
                Email = request.Email!,
                Uid = Guid.NewGuid(),
                Status = Models.Enums.DataStatus.Active,
                CreationDate = dateNow,
                LastModification = dateNow,
                PasswordHash = password.Hash,
                PasswordSalt = password.Salt,
            };
            
            try
            {
                var hasUser = await UserServiceHelper.HasUserBy(request.Email!, userRepository);

                if (hasUser)
                    return BadRequest(ErrorEnum.UserEmailAlreadyExists.GetDescription());

                var createResult = await userRepository.CreateAsync(entity);

                if (createResult == 0)
                    InternalError(ErrorEnum.InternalCreateDbError);
            }
            catch(DbUpdateException)
            {                
                return BadRequest(ErrorEnum.UserEmailAlreadyExists.GetDescription());
            }
            catch
            {
                return InternalError(ErrorEnum.InternalDbError.GetDescription());
            }

            //Ok
            var response = new UserCreatePostResponse() { Uid = entity.Uid };
            return Ok(response);
        }

        /// <summary>
        /// Login do usuário.
        /// </summary>
        public async Task<IServiceResult> LoginAsync(UserLoginPostRequest request)
        {
            //Validações da requisição
            request.Sanitize();

            var result = ValidatorHelper.Validate<UserLoginPostValidation, UserLoginPostRequest>(request);

            if (!result.IsValid)
                return BadRequest(ErrorEnum.UserInvalidLogin.GetDescription());

            try
            {
                //Acesso ao banco
                UserLoginPostResponse? response = null;

                var userEntity = await userRepository.SelectAsync(e => new UserEntity()
                {
                    PasswordHash = e.PasswordHash,
                    PasswordSalt = e.PasswordSalt,
                    Email = e.Email
                }, e => e.Email == request.Email);

                if (userEntity == null)
                {
                    return BadRequest(ErrorEnum.UserInvalidLogin.GetDescription());
                }

                var requestHash = Password.GetPasswordHash(request.Password!, userEntity.PasswordSalt);

                if (userEntity.PasswordHash != requestHash.Hash)
                    return BadRequest(ErrorEnum.UserInvalidLogin.GetDescription());

                var token = BearerToken.Generate(DateTime.Now.Add(TimeSpan.FromDays(30)));

                response = new UserLoginPostResponse()
                {
                    Token = token,
                };

                return Ok(response);
            }
            catch
            {
                return InternalError(ErrorEnum.InternalDbError.GetDescription());
            }            
        }
    }    
}
