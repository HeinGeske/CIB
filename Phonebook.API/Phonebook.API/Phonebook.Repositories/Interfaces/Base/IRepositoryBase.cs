using Phonebook.Data.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Phonebook.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T> where T : Entity
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, object>> includes = null);
        Task<List<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selectFields, Expression<Func<T, bool>> predicate = null, Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null, Expression<Func<T, object>> includes = null);
        Task<T> GetOneAsync(Expression<Func<T, bool>> predicate = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, object>> includes = null);
        Task<TResult> GetOneAsync<TResult>(Expression<Func<T, TResult>> selectFields, Expression<Func<T, bool>> predicate = null, Func<IQueryable<TResult>, IOrderedQueryable<TResult>> orderBy = null, Expression<Func<T, object>> includes = null);
    }
}
