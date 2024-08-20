using Comunidades.ApiService.Models.Data;
using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories.Interfaces
{
    public interface IUserRepository :
        ICreatableRepository<UserEntity>,
        IReadableRepository<UserEntity>
    {
        Task<int> CountAsync(Expression<Func<UserEntity, bool>> whereExpression);
    }
}
