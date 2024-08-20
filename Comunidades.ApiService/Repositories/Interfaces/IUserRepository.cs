using Comunidades.ApiService.Models.Data;

namespace Comunidades.ApiService.Repositories.Interfaces
{
    public interface IUserRepository :
        ICreatableRepository<UserEntity>,
        IReadableRepository<UserEntity>
    {
    }
}
