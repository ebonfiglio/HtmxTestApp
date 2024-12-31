using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HtmxTestApp.DAL.Repositories
{
    public interface IGenericRepository
    {
        public abstract class GenericRepository<T>
         : IRepository<T> where T : class
        {

            protected ApplicationDbContext _context;

            public GenericRepository(ApplicationDbContext context)
            {
                _context = context;
            }
            public virtual async Task<T> AddAsync(T entity)
            {
                var result = await _context.Set<T>().AddAsync(entity);
                return result.Entity;
            }

            public virtual Task<T> UpdateAsync(T entity)
            {
                _context.Entry(entity).State = EntityState.Modified;
                return Task.FromResult(entity);
            }

            public virtual async Task<T> GetByIdAsync(Guid id, bool asNoTracking = false)
            {
                var query = _context.Set<T>().AsQueryable();
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
            }

            public virtual IQueryable<T> GetAll(bool asNoTracking = false)
            {
                var query = _context.Set<T>().AsQueryable();
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                return query;
            }

            public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool asNoTracking = false)
            {
                var query = _context.Set<T>().Where(predicate);
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                return query;
            }

            public virtual void Delete(T entity)
            {
                _context.Set<T>().Remove(entity);
            }
        }
    }
}
