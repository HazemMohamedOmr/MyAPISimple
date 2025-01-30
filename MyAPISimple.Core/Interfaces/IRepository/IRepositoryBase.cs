using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyAPISimple.Core.Interfaces.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        // Query
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<(IEnumerable<T> Items, int TotalCount)> GetAllAsync(int pageNumber, int pageSize);

        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<(IEnumerable<T> Items, int TotalCount)> GetAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize);
        Task<(IEnumerable<T> Items, int TotalCount)> GetAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes);

        // Aggregations
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<T, bool>> predicate);
        Task<decimal> SumAsync(Expression<Func<T, decimal>> selector);
        Task<decimal> SumAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>> predicate);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        // Single Record with Criteria
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task<T> FirstOrDefaultIncludingAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        // Sorting
        Task<IEnumerable<T>> GetAllOrderedByAsync<TKey>(Expression<Func<T, TKey>> orderBy, bool ascending = true); // Urgent replace hard coded values
        Task<IEnumerable<T>> FindOrderedByAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, bool ascending = true); // Urgent replace hard coded values

        // Projection
        Task<IEnumerable<TResult>> SelectAsync<TResult>(Expression<Func<T, TResult>> selector);
        Task<IEnumerable<TResult>> SelectIncludingAsync<TResult>(Expression<Func<T, TResult>> selector, params Expression<Func<T, object>>[] includes);

        // Bulk Operations
        Task AddBulkAsync(IEnumerable<T> entities);
        Task UpdateBulkAsync(IEnumerable<T> entities);
        Task DeleteBulkAsync(IEnumerable<T> entities);
    }
}