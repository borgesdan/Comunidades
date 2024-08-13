using Comunidades.ApiService.Models.Data;
using System.Linq.Expressions;
using System;
using Comunidades.ApiService.Repositories.Contexts;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Comunidades.ApiService.Repositories
{
    /// <summary>
    /// Repositório base que implementa métodos de acesso ao banco com EntityFramework.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected AppDbContext appContext;

        public BaseRepository(AppDbContext appContext)
        {
            this.appContext = appContext ?? throw new ArgumentNullException(nameof(appContext));
        }

        public async Task<T> CreateAsync(T entity)
        {
            appContext.Add(entity);
            await appContext.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            appContext.Remove(entity);
            var result = await appContext.SaveChangesAsync();

            return result != 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereExpression)
        {
            return await appContext.Set<T>().Where(whereExpression).ToListAsync();
        }

        public async Task<T?> GetAsync(int id)
        {
            return await appContext.Set<T>().Where(e => e.Id == id).FirstOrDefaultAsync();
        }

        public async Task<T?> GetAsync(Expression<Func<T, bool>> whereExpression)
        {
            return await appContext.Set<T>().Where(whereExpression).FirstOrDefaultAsync();
        }

        public async Task<T> UpdateAsync(T entity)
        {
            appContext.Update(entity);
            await appContext.SaveChangesAsync();

            return entity;
        }
    }
}
