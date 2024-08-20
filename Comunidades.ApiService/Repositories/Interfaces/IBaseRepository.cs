using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories.Interfaces
{
    /// <summary>
    /// Representa um repositório capaz de registrar dados.
    /// </summary>
    public interface ICreatableRepository<T>
    {
        /// <summary>Cria um novo registro no banco de dados.</summary>
        Task<int> CreateAsync(T entity);
    }

    /// <summary>
    /// Representa um repositório capaz de atualizar dados.
    /// </summary>
    public interface IUpdatableRepository<T>
    {
        /// <summary>Atualiza um registro no banco de dados.</summary>
        Task<int> UpdateAsync(T entity);
    }

    /// <summary>
    /// Representa um repositório capaz de deletar dados.
    /// </summary>
    public interface IDeletableRepository<T>
    {
        /// <summary>Deleta um registro no banco de dados.</summary>
        Task<int> DeleteAsync(T entity);
    }   

    /// <summary>
    /// Representa um repositório capaz de selecionar dados.
    /// </summary>
    public interface ISelectableRepository<T>
    {
        /// <summary>
        /// Realiza um select na base de dados com a informação do tipo de destino.
        /// </summary>
        /// <param name="expression">A expressão com os dados de T a serem selecionados para o tipo de destino.</param>
        /// <param name="whereExpression">A expressão de condição da consulta</param>
        Task<TSeletedType?> SelectAsync<TSeletedType>(Expression<Func<T, TSeletedType>> selector, Expression<Func<T, bool>> whereExpression);
        /// <summary>
        /// Realiza um select na base de dados com a informação do tipo de destino e retorna mais de um registro.
        /// </summary>
        /// <param name="expression">A expressão com os dados de T a serem selecionados para o tipo de destino.</param>
        /// <param name="whereExpression">A expressão de condição da consulta</param>
        Task<IEnumerable<TSeletedType?>> SelectManyAsync<TSeletedType>(Expression<Func<T, IEnumerable<TSeletedType>>> selector, Expression<Func<T, bool>> whereExpression);
    }

    /// <summary>
    /// Representa um repositório que realizar operações de criação, atualização, deleção e seleção de dados.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository<T> 
        : ICreatableRepository<T>, IUpdatableRepository<T>, IDeletableRepository<T>, ISelectableRepository<T> where T: class
    {

    }
}
