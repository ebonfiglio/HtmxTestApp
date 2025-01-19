using System.Linq.Expressions;

namespace HtmxTestApp.Domain.Services.Contracts
{
    public interface IGenericService<TEntity, TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
    }
}
