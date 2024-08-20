using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;
using Comunidades.ApiService.Repositories.Extensions;
using Comunidades.ApiService.Repositories.Interfaces;

namespace Comunidades.ApiService.Repositories
{
    public class CommunityRepository : 
        DbContextRepository,
        ICommunityRepository
    {
        public CommunityRepository(AppDbContext context) : base(context) { }

        public Task<int> CreateAsync(CommunityEntity entity)
        {
            return this.CreateAsync(appContext, entity);
        }
    }
}
