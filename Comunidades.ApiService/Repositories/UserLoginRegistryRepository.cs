using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;
using Comunidades.ApiService.Repositories.Extensions;
using Comunidades.ApiService.Repositories.Interfaces;

namespace Comunidades.ApiService.Repositories
{
    public class UserLoginRegistryRepository : DbContextRepository, IUserLoginRegistryRepository
    {
        public UserLoginRegistryRepository(AppDbContext appContext) : base(appContext)
        {
        }

        public async Task<int> CreateAsync(UserLoginRegistryEntity entity)
        {
            return await this.CreateAsync(appContext, entity);
        }
    }
}
