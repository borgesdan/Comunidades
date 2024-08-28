using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;
using Comunidades.ApiService.Repositories.Extensions;
using Comunidades.ApiService.Repositories.Interfaces;
using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories
{
    public class UserRepository : DbContextRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public virtual async Task<int> CreateAsync(UserEntity entity)
        {
            return await this.CreateAsync(appContext, entity);
        }

        public virtual async Task<TSeletedType?> SelectAsync<TSeletedType>(Expression<Func<UserEntity, TSeletedType>> selector, Expression<Func<UserEntity, bool>> whereExpression)
        {
            return await this.SelectAsync(appContext, selector, whereExpression);
        }        

        public virtual async Task<int> CountAsync(Expression<Func<UserEntity, bool>> whereExpression)
        {
            return await this.CountAsync(appContext, whereExpression);
        }
    }
}
