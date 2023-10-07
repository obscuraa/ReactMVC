﻿using System.Linq.Expressions;

namespace ReactMVC.Repository.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAllAsync(
            Expression <Func <T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );

        Task<T> GetAsync(Expression<Func<T, bool>> expression, List<string> includes = null);
        Task Insert(T entity);
        Task InsertRange(IEnumerable<T> entities);
        Task Delete (int id);
        void DeleteRange(IEnumerable<T> entities);
        void Update (T entity);
    }
}
