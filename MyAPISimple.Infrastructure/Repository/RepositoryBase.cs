﻿using Microsoft.EntityFrameworkCore;
using MyAPISimple.Core.Constants;
using MyAPISimple.Core.Interfaces.IRepository;
using MyAPISimple.Infrastructure.Data;
using System.Linq.Expressions;

namespace MyAPISimple.Infrastructure.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        // ---------------------- READ OPERATIONS (NO TRACKING) ----------------------

        public async Task<T> GetByIdAsync<TId>(TId id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes)
        {
            return await ApplyIncludes(_dbSet.AsNoTracking(), includes).ToListAsync();
        }

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetAllPagedAsync(int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            var query = ApplyIncludes(_dbSet.AsNoTracking(), includes);
            int totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }

        public async Task<IEnumerable<T>> GetFilteredAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await ApplyIncludes(_dbSet.AsNoTracking().Where(predicate), includes).ToListAsync();
        }

        public async Task<(IEnumerable<T> Items, int TotalCount)> GetFilteredPagedAsync(Expression<Func<T, bool>> predicate, int pageNumber, int pageSize, params Expression<Func<T, object>>[] includes)
        {
            var query = ApplyIncludes(_dbSet.AsNoTracking().Where(predicate), includes);
            int totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, totalCount);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
        {
            return await ApplyIncludes(_dbSet.AsNoTracking(), includes).FirstOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<T>> GetAllSortedAsync<TKey>(Expression<Func<T, TKey>> orderBy, string orderByDirection = SDs.Ascending)
        {
            var query = _dbSet.AsNoTracking();
            return orderByDirection == SDs.Ascending
                ? await query.OrderBy(orderBy).ToListAsync()
                : await query.OrderByDescending(orderBy).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetFilteredSortedAsync<TKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TKey>> orderBy, string orderByDirection = SDs.Ascending, params Expression<Func<T, object>>[] includes)
        {
            var query = ApplyIncludes(_dbSet.AsNoTracking().Where(predicate), includes);
            return orderByDirection == SDs.Ascending
                ? await query.OrderBy(orderBy).ToListAsync()
                : await query.OrderByDescending(orderBy).ToListAsync();
        }

        // ---------------------- AGGREGATE FUNCTIONS ----------------------

        public async Task<int> CountAsync(Expression<Func<T, bool>>? predicate = null)
        {
            return await (predicate == null ? _dbSet.CountAsync() : _dbSet.CountAsync(predicate));
        }

        public async Task<decimal> SumAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null)
        {
            return await (predicate == null ? _dbSet.SumAsync(selector) : _dbSet.Where(predicate).SumAsync(selector));
        }

        public async Task<decimal> MaxAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null)
        {
            return await (predicate == null ? _dbSet.MaxAsync(selector) : _dbSet.Where(predicate).MaxAsync(selector));
        }

        public async Task<decimal> MinAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null)
        {
            return await (predicate == null ? _dbSet.MinAsync(selector) : _dbSet.Where(predicate).MinAsync(selector));
        }

        public async Task<decimal> AverageAsync(Expression<Func<T, decimal>> selector, Expression<Func<T, bool>>? predicate = null)
        {
            return await (predicate == null ? _dbSet.AverageAsync(selector) : _dbSet.Where(predicate).AverageAsync(selector));
        }

        // ---------------------- LOGICAL OPERATIONS ----------------------

        public async Task<bool> AnyAsync(Expression<Func<T, bool>>? predicate = null)
        {
            return await (predicate == null ? _dbSet.AnyAsync() : _dbSet.AnyAsync(predicate));
        }

        public async Task<bool> AllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.AllAsync(predicate);
        }

        // ---------------------- CUD OPERATIONS ----------------------

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities);
            return entities;
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        // ---------------------- PROJECTION ----------------------

        public async Task<IEnumerable<TResult>> ProjectAsync<TResult>(Expression<Func<T, TResult>> selector, params Expression<Func<T, object>>[] includes)
        {
            return await ApplyIncludes(_dbSet.AsNoTracking(), includes).Select(selector).ToListAsync();
        }

        // ---------------------- TRANSACTIONS ----------------------

        public async Task BeginTransactionAsync()
        {
            if (_context.Database.CurrentTransaction == null)
                await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_context.Database.CurrentTransaction != null)
                await _context.Database.RollbackTransactionAsync();
        }

        // ---------------------- BULK OPERATIONS ----------------------

        public async Task AddBulkAsync(IEnumerable<T> entities)
        {
            await _dbSet.AddRangeAsync(entities); // TODO Adjust Bulking Operation - Add
        }

        public async Task UpdateBulkAsync(IEnumerable<T> entities)
        {
            _dbSet.UpdateRange(entities); // TODO Adjust Bulking Operation - Update
        }

        public async Task DeleteBulkAsync(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities); // TODO Adjust Bulking Operation - Delete
        }

        // ---------------------- PRIVATE HELPER METHOD ----------------------

        private IQueryable<T> ApplyIncludes(IQueryable<T> query, params Expression<Func<T, object>>[] includes)
        {
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }
            return query;
        }
    }
}