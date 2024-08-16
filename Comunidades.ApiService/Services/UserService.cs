using Azure.Core;
using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Models.Responses;
using Comunidades.ApiService.Repositories;
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

            //Validations
            var result = ValidatorHelper.Validate<UserCreatePostValidation, UserCreatePostRequest>(request);

            if (!result.IsValid)
                return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);

            //Hashing a password
            const int hashInteration = 3;
            string passwordSalt = PasswordHasher.GenerateSalt();
            string passwordPaper = new(passwordSalt.Reverse().ToArray());
            string passwordHash = PasswordHasher.ComputeHash(request.Password!, passwordSalt, passwordPaper, hashInteration);
            var dateNow = DateTime.Now;

            //Our entity
            var entity = new UserEntity
            {
                FullName = request.FullName,
                UserName = request.UserName,
                Email = request.Email,
                Uid = Guid.NewGuid(),
                Status = Models.Enums.DataStatus.Active,
                CreationDate = dateNow,
                LastModification = dateNow,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            //Posting to the database
            try
            {
                //TODO: verificar se o email já existe

                await userRepository.CreateAsync(entity);
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

            //Acesso ao banco
            UserLoginPostResponse? response = null;

            try
            {
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

                var requestHash = GetPasswordHash(request.Password!, userEntity.PasswordSalt);

                if (userEntity.PasswordHash != requestHash.Hash)
                    return BadRequest(ErrorEnum.UserInvalidLogin.GetDescription());

                response = new UserLoginPostResponse()
                {
                    Token = "TODO: Gerar Token",
                };
            }
            catch
            {
                return InternalError(ErrorEnum.InternalDbError.GetDescription());
            }

            return Ok(response);
        }

        /// <summary>
        /// Obtém um objeto PasswordHash. O salt será criado internamente caso seja nulo.
        /// </summary>        
        static public PasswordHash GetPasswordHash(string password, string? salt = null)
        {
            salt ??= PasswordHasher.GenerateSalt();

            const int hashInteration = 3;
            string passwordPaper = new(salt.Reverse().ToArray());
            string passwordHash = PasswordHasher.ComputeHash(password, salt, passwordPaper, hashInteration);

            return new PasswordHash()
            {
                Hash = passwordHash,
                Salt = salt,
            };
        }
    }

    public class PasswordHash()
    {
        public string? Hash { get; set; }
        public string? Salt { get; set; }
    }
}
