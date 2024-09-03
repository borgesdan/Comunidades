using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Interfaces;
using Comunidades.ApiService.Services.Interfaces;

namespace Comunidades.ApiService.Services
{
    public class UserLoginRegistryService : BaseService, IUserLoginRegistryService
    {
        readonly IUserLoginRegistryRepository userLoginRepository;
        readonly ILogger logger;

        public UserLoginRegistryService(ILogger<UserLoginRegistryService> logger, IUserLoginRegistryRepository userLoginRepository)
        {
            this.logger = logger;
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
                {
                    throw new Exception();
                }                    

                return Ok();
            }
            catch
            {
                logger.LogError("message");
                return InternalError();
            }            
        }
    }
}
