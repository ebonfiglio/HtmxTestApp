using System.Linq.Expressions;

namespace HtmxTestApp.Domain.Services.Contracts
{
    public interface IGenericService<TEntity, TKey>
    {
        Task<TEntity> GetAsync(TKey id);
        List<TEntity> GetAll();
        List<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey id);
    }
}
