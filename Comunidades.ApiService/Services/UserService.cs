using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services.Validations;
using Comunidades.ApiService.Shared;

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
            //Validations
            var validator = new UserCreatePostValidation();
            var result = validator.Validate(request);

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
                await userRepository.CreateAsync(entity);
            }
            catch
            {
                return InternalError(ErrorEnum.InternalDbError.GetDescription());
            }

            //Ok
            return Ok(entity.Uid.ToString());
        }
    }
}
