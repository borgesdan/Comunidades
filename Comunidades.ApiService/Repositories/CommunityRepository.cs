using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;
using Comunidades.ApiService.Repositories.Interfaces;

namespace Comunidades.ApiService.Repositories
{
    public class CommunityRepository : BaseRepository<CommunityEntity>, ICommunityRepository
    {
        public CommunityRepository(AppDbContext context) : base(context) { }
    }
}
