using Comunidades.ApiService.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Comunidades.ApiService.Repositories.Extensions
{
    public static class IDbContextRepositoryExtensions
    {
        /// <summary>
        /// Método de extensão para ICreatableRepository responsável por disponibilizar um rápido acesso para criação no banco de dados.
        /// </summary>
        /// <typeparam name="T">Um tipo referência</typeparam>
        /// <param name="repository">Uma classe que implementa ICreatableRepository</param>
        /// <param name="context">O contexto do EntityFramework.</param>
        /// <param name="entity">A entidade a ser registrada no banco.</param>
        /// <returns>Retorna o número de entradas escritas no banco.</returns>
        public static async Task<int> CreateAsync<T>(this ICreatableRepository<T> repository, DbContext context, T entity) where T : class
        {
            if (entity == null)
                return 0;

            context.Add(entity);
            var entriesWritten = await context.SaveChangesAsync();

            return entriesWritten;
        }

        /// <summary>
        /// Método de extensão para IUpdatableRepository responsável por disponibilizar um rápido acesso para atualização no banco de dados.
        /// </summary>
        /// <typeparam name="T">Um tipo referência</typeparam>
        /// <param name="repository">Uma classe que implementa IUpdatableRepository</param>
        /// <param name="context">O contexto do EntityFramework.</param>
        /// <param name="entity">A entidade a ser registrada no banco.</param>
        /// <returns>Retorna o número de entradas escritas no banco.</returns>
        public static async Task<int> UpdateAsync<T>(this IUpdatableRepository<T> repository, DbContext context, T entity) where T : class
        {
            if(entity == null)
                return 0;

            context.Update(entity);
            var entriesWritten = await context.SaveChangesAsync();

            return entriesWritten;
        }

        /// <summary>
        /// Método de extensão para IDeletableRepository responsável por disponibilizar um rápido acesso para deleção no banco de dados.
        /// </summary>
        /// <typeparam name="T">Um tipo referência</typeparam>
        /// <param name="repository">Uma classe que implementa IUpdatableRepository</param>
        /// <param name="context">O contexto do EntityFramework.</param>
        /// <param name="entity">A entidade a ser registrada no banco.</param>
        /// <returns>Retorna o número de entradas escritas no banco.</returns>
        public static async Task<int> DeleteAsync<T>(this IDeletableRepository<T> repository, DbContext context, T entity) where T : class
        {
            if (entity == null)
                return 0;

            context.Remove(entity);
            var entriesWritten = await context.SaveChangesAsync();

            return entriesWritten;
        }

        /// <summary>
        /// Método de extensão para ISelectableRepository responsável por disponibilizar um rápido acesso para seleção no banco de dados.
        /// </summary>
        /// <typeparam name="T">Um tipo referência</typeparam>
        /// <typeparam name="TSeletedType">O tipo a ser retornado com a seleção dos dados.</typeparam>
        /// <param name="repository">Uma classe que implementa IUpdatableRepository</param>
        /// <param name="context">O contexto do EntityFramework.</param>
        /// <param name="selector">A expressão de seleção dos dados.</param>
        /// <param name="whereExpression">A expressão de condição para filtragem dos dados.</param>
        /// <returns>Retorna os dados selecionados pela condição informada com o tipo especificado.</returns>
        public static async Task<TSeletedType?> SelectAsync<T, TSeletedType>(this ISelectableRepository<T> repository, DbContext context, Expression<Func<T, TSeletedType>> selector, Expression<Func<T, bool>> whereExpression) where T : class
        {
            var query = context.Set<T>().AsQueryable();
            query = query.Where(whereExpression);
            var query2 = query.Select(selector);
            return await query2.FirstOrDefaultAsync();
        }

        /// <summary>
        /// Método de extensão para ISelectableRepository responsável por disponibilizar um rápido acesso para seleção com mais de um registro no banco de dados.
        /// </summary>
        /// <typeparam name="T">Um tipo referência</typeparam>
        /// <typeparam name="TSeletedType">O tipo a ser retornado com a seleção dos dados.</typeparam>
        /// <param name="repository">Uma classe que implementa IUpdatableRepository</param>
        /// <param name="context">O contexto do EntityFramework.</param>
        /// <param name="selector">A expressão de seleção dos dados.</param>
        /// <param name="whereExpression">A expressão de condição para filtragem dos dados.</param>
        /// <returns>Retorna os dados selecionados pela condição informada com o tipo especificado em uma lista enumerável.</returns>
        public static async Task<IEnumerable<TSeletedType?>> SelectManyAsync<T, TSeletedType>(this ISelectableRepository<T> repository, DbContext context, Expression<Func<T, IEnumerable<TSeletedType>>> selector, Expression<Func<T, bool>> whereExpression) where T : class
        {
            var query = context.Set<T>().AsQueryable();
            query = query.Where(whereExpression);
            var query2 = query.SelectMany(selector);
            return await query2.ToListAsync();
        }
    }
}
