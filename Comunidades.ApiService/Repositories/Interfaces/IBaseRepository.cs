using Comunidades.ApiService.Models.Data;
using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        /// <summary>Cria um novo registro no banco de dados.</summary>
        Task<int> CreateAsync(T entity);
        /// <summary>Atualiza um registro no banco de dados.</summary>
        Task<int> UpdateAsync(T entity);
        /// <summary>Deleta um registro no banco de dados.</summary>
        Task<int> DeleteAsync(T entity);
        /// <summary>Obtém um registro do banco de dados.</summary>
        Task<T?> GetAsync(int id);
        /// <summary>Obtém um registro do banco de dados através de uma condição.</summary>
        Task<T?> GetAsync(Expression<Func<T, bool>> whereExpression);
        /// <summary>Obtém todos os registros no banco de dados através de uma condição.</summary>
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> whereExpression);
        /// <summary>Obtém um objeto IQueryable para fórmulas de consulta e acesso ao banco.</summary>
        public IQueryable<T> ToQuery();
        /// <summary>
        /// Realiza um select na base de dados com a informação do tipo de destino.
        /// </summary>
        /// <param name="expression">A expressão com os dados de T a serem selecionados para o tipo de destino.</param>
        /// <param name="whereExpression">A expressão de condição da consulta</param>
        Task<TSeletedType?> SelectAsync<TSeletedType>(Expression<Func<T, TSeletedType>> selector, Expression<Func<T, bool>> whereExpression);
    }
}
