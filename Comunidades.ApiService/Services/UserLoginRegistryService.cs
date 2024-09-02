using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Interfaces;
using Comunidades.ApiService.Services.Interfaces;

namespace Comunidades.ApiService.Services
{
    public class UserLoginRegistryService : BaseService, IUserLoginRegistryService
    {
        readonly IUserLoginRegistryRepository userLoginRepository;

        public UserLoginRegistryService(IUserLoginRegistryRepository userLoginRepository)
        {
            this.userLoginRepository = userLoginRepository;
        }

        public async Task<IServiceResult> CreateAsync(int userId)
        {
            if (userId <= 0)
                return BadRequest();

            try
            {
                var entity = new UserLoginRegistryEntity
                {
                    UserId = userId,
                    LoginDate = DateTime.Now,
                };

                var createResult = await userLoginRepository.CreateAsync(entity);

                if (createResult == 0)
                    return InternalError();

                return Ok();
            }
            catch
            {
                return InternalError();
            }            
        }
    }
}
