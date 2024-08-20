using Comunidades.ApiService.Models.Data;
using Comunidades.ApiService.Repositories.Contexts;
using Comunidades.ApiService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories
{
    /// <summary>
    /// Repositório base que implementa métodos de acesso ao banco com EntityFramework.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected AppDbContext appContext;

        public AppDbContext AppDbContext { get { return appContext; } }

        public BaseRepository(AppDbContext appContext)
        {
            this.appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public virtual async Task<int> CreateAsync(T entity)
        {
            appContext.Add(entity);
            var entriesWritten = await appContext.SaveChangesAsync();

            return entriesWritten;
        }

        public virtual async Task<int> DeleteAsync(T entity)
        {
            appContext.Remove(entity);
            var entriesWritten = await appContext.SaveChangesAsync();

            return entriesWritten;
        }

        public virtual async Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> whereExpression)
        {
            return await appContext.Set<T>().Where(whereExpression).ToListAsync();
        }       

        public virtual async Task<T?> GetAsync(Expression<Func<T, bool>> whereExpression)
        {
            return await appContext.Set<T>().Where(whereExpression).FirstOrDefaultAsync();
        }

        public virtual async Task<int> UpdateAsync(T entity)
        {
            appContext.Update(entity);
            var entriesWritten = await appContext.SaveChangesAsync();

            return entriesWritten;
        }

        public virtual IQueryable<T> ToQuery() 
        {
            var query = appContext.Set<T>().AsQueryable();
            return query;
        }

        public virtual async Task<T?> SelectAsync(Expression<Func<T, T>> selector, Expression<Func<T, bool>> whereExpression)
        {
            var query = ToQuery();
            query = query.Select(selector);
            query = query.Where(whereExpression);

            return await query.FirstOrDefaultAsync();
        }

        public virtual async Task<TSeletedType?> SelectAsync<TSeletedType>(Expression<Func<T, TSeletedType>> selector, Expression<Func<T, bool>> whereExpression)
        {
            var query = ToQuery();
            query = query.Where(whereExpression);
            var query2 = query.Select(selector);
            return await query2.FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TSeletedType?>> SelectManyAsync<TSeletedType>(Expression<Func<T, IEnumerable<TSeletedType>>> selector, Expression<Func<T, bool>> whereExpression)
        {
            var query = ToQuery();
            query = query.Where(whereExpression);
            var query2 = query.SelectMany(selector);
            return await query2.ToListAsync();
        }
    }
}
