﻿using MyAPISimple.Core.Constants;
using System.Linq.Expressions;

namespace MyAPISimple.Core.Interfaces.IRepository
{
    public interface IRepositoryBase<T> where T : class
    {
        // Query
        Task<T> GetByIdAsync<TId>(TId id);
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<(IEnumerable<T> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);
        Task<(IEnumerable<T> Items, int TotalCount)> GetFilteredPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes);

        // Aggregations
        Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null);
        Task<decimal> SumAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null);
        Task<decimal> MaxAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null);
        Task<decimal> MinAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null);
        Task<decimal> AverageAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null);

        // Logical Operations
        Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null);
        Task<bool> AllAsync(Expression<Func<T, bool>> predicate);

        // Create / Update / Delete
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        T Update(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entities);
        void Delete(T entity);
        void DeleteRange(IEnumerable<T> entities);

        // Single Record
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes);

        // Sorting
        Task<IEnumerable<T>> GetAllSortedAsync<TKey>(Expression<Func<T, TKey>> orderBy, string orderByDirection = SDs.Ascending);
        Task<IEnumerable<T>> GetFilteredSortedAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, string orderByDirection = SDs.Ascending, params Expression<Func<T, object>>[] includes);

        // Projection
        Task<IEnumerable<TResult>> ProjectAsync<TResult>(Expression<Func<T, TResult>> selector, params Expression<Func<T, object>>[] includes);

        // Transactions
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

        // Bulk Operations
        Task AddBulkAsync(IEnumerable<T> entities);
        Task UpdateBulkAsync(IEnumerable<T> entities);
        Task DeleteBulkAsync(IEnumerable<T> entities);
    }
}