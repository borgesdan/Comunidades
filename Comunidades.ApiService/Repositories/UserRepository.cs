using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;

namespace Comunidades.ApiService.Repositories
{    
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
