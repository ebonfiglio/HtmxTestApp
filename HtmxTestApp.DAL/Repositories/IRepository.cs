using System.Linq.Expressions;

namespace HtmxTestApp.DAL.Repositories
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<T> GetByIdAsync(Guid id, bool asNoTracking = false, params Expression<Func<T, object>>[] includes);

        IQueryable<T> GetAll(bool asNoTracking = false, params Expression<Func<T, object>>[] includes);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params Expression<Func<T, object>>[] includes);

        Task DeleteAsync(T entity);
    }
}
