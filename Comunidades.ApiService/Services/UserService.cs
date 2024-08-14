using Comunidades.ApiService.Extensions;
using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Models.Requests;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services.Validations;

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
        public async Task<IServiceResult> Create(UserCreateRequest request)
        {
            var validator = new UserCreateValidation();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var dateNow = DateTime.Now;

            var entity = new UserEntity
            {
                Name = request.Name,
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                Uid = Guid.NewGuid(),
                Status = Models.Enums.DataStatus.Active,
                CreationDate = dateNow,
                LastModification = dateNow,
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
