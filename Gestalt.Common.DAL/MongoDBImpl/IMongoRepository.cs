namespace Gestalt.Common.DAL.MongoDBImpl
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IMongoRepository<T> where T : IIdentifiable
    {
        Task<T> GetAsync(string id);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddAsync(IEnumerable<T> entity);
        Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
        Task UpdateAsync(T agreement);
        Task DropCollection();
    }
}