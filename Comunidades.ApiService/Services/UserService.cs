using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories;
using Comunidades.ApiService.Services.Validations;

namespace Comunidades.ApiService.Services
{
    public class UserCreateRequest
    {
        public string? Name { get; set; }
    }

    public class UserService : BaseService
    {
        readonly UserRepository userRepository;

        public UserService(UserRepository userRepository) 
        {
            this.userRepository = userRepository;
        }

        public async Task<IServiceResult> Create(UserCreateRequest request)
        {
            var validator = new UserCreateValidation();
            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors.FirstOrDefault()?.ErrorMessage);
            }

            var entity = new UserEntity
            {
                Name = request.Name
            };

            try
            {
                await userRepository.CreateAsync(entity);
            }
            catch
            {
                return InternalError();
            }

            return Ok();
        }
    }
}
