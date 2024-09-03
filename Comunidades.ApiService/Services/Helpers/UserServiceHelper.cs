using Comunidades.ApiService.Repositories.Interfaces;
using Comunidades.ApiService.Services.Interfaces;

namespace Comunidades.ApiService.Services.Helpers
{
    public static class UserServiceHelper
    {
        /// <summary>
        /// Obtém true caso exista o usuário por um email.
        /// </summary>
        public static async Task<bool> HasUserBy(string email, IUserRepository userRepository)
        {            
            var matchedEmailEntity = await userRepository.CountAsync(e => e.Email == email);

            return matchedEmailEntity != 0;
        }

        /// <summary>
        /// Registra o login do usuário.
        /// </summary>
        public static async Task RegisterLogin(int userId, IUserLoginRegistryService service, ILogger logger)
        {
            var loginRegistryResult = await service.CreateAsync(userId);

            var registryCode = loginRegistryResult.StatusCode();

            if (!loginRegistryResult.Succeeded && (int)registryCode < 500)
            {
                logger.LogWarning("Unable to register login.");
            }
        }
    }
}
