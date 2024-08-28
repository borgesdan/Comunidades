using Comunidades.ApiService.Repositories.Interfaces;

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
    }
}
