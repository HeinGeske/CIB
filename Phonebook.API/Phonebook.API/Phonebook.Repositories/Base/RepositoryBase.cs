using Microsoft.EntityFrameworkCore;
using Phonebook.Data;
using Phonebook.Data.Entities.Base;
using Phonebook.Repositories.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phonebook.Repositories.Base
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : Entity
    {
        protected readonly PhonebookContext _dbContext;

        public RepositoryBase(PhonebookContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }
        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, object>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null) query.Include(includes);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).ToListAsync();

            return await query.ToListAsync();
        }

        public async Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selectFields, Expression<Func<T, bool>> predicate = null, Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null, Expression<Func<T, object>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null) query.Include(includes);

            if (predicate != null) query = query.Where(predicate);

            IQueryable<TResult> queryResult = query.Select(selectFields);

            if (orderBy != null)
                return await orderBy(queryResult).ToListAsync();

            return await queryResult.ToListAsync();
        }


        public async Task<T> GetOneAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, object>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null) query.Include(includes);

            if (predicate != null) query = query.Where(predicate);

            if (orderBy != null)
                return await orderBy(query).FirstOrDefaultAsync();

            return await query.FirstOrDefaultAsync();
        }

        public async Task<TResult> GetOneAsync<TResult>(Expression<Func<T, TResult>> selectFields, Expression<Func<T, bool>> predicate = null, Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null, Expression<Func<T, object>> includes = null)
        {
            IQueryable<T> query = _dbContext.Set<T>();

            if (includes != null) query.Include(includes);

            if (predicate != null) query = query.Where(predicate);

            IQueryable<TResult> queryResult = query.Select(selectFields);

            if (orderBy != null)
                return await orderBy(queryResult).FirstOrDefaultAsync();

            return await queryResult.FirstOrDefaultAsync();
        }

    }
}
