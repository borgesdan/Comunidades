using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;

namespace Comunidades.ApiService.Repositories.Interfaces
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }
    }
}
