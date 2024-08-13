using Comunidades.ApiService.Models.Data;
using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>Cria um novo registro no banco de dados.</summary>
        Task<T> CreateAsync(T entity);
        /// <summary>Atualiza um registro no banco de dados.</summary>
        Task<T> UpdateAsync(T entity);
        /// <summary>Deleta um registro no banco de dados.</summary>
        Task<bool> DeleteAsync(T entity);
        /// <summary>Obtém um registro do banco de dados.</summary>
        Task<T?> GetAsync(int id);
        /// <summary>Obtém um registro do banco de dados através de uma condição.</summary>
        Task<T?> GetAsync(Expression<Func<T, bool>> whereExpression);
        /// <summary>Obtém todos os registros no banco de dados através de uma condição.</summary>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereExpression);
    }
}
