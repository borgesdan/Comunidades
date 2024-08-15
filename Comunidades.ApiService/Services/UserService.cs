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
    public class UserService : BaseService
    {
        readonly UserRepository userRepository;

        public UserService(UserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Cria um novo usuário no banco.
        /// </summary>
        public async Task<IServiceResult> Create(UserCreatePostRequest request)
        {
            var validator = new UserCreatePostValidation();
            var result = validator.Validate(request);

            if (!result.IsValid)
                return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);

            var dateNow = DateTime.Now;
            const int hashInteration = 3;
            const string passwordPaper = "_+@#^^^ghty56";
            string passwordSalt = PasswordHasher.GenerateSalt();
            string passwordHash = PasswordHasher.ComputeHash(request.Password!, passwordSalt, passwordPaper, hashInteration);

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

            try
            {
                await userRepository.CreateAsync(entity);
            }
            catch
            {
                return InternalError(ErrorEnum.InternalDbError.GetDescription());
            }

            return Ok(entity.Uid.ToString());
        }
    }
}
