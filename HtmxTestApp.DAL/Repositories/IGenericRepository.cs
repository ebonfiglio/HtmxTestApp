using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HtmxTestApp.DAL.Repositories
{
    public interface IGenericRepository
    {
        public abstract class GenericRepository<T> : IRepository<T> where T : class
        {
            private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

            public GenericRepository(IDbContextFactory<ApplicationDbContext> contextFactory)
            {
                _contextFactory = contextFactory;
            }

            public virtual async Task<T> AddAsync(T entity)
            {
                using var context = _contextFactory.CreateDbContext();
                var result = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return result.Entity;
            }

            public virtual async Task<T> UpdateAsync(T entity)
            {
                using var context = _contextFactory.CreateDbContext();
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return entity;
            }

            public virtual async Task<T> GetByIdAsync(Guid id, bool asNoTracking = false, params Expression<Func<T, object>>[] includes)
            {
                using var context = _contextFactory.CreateDbContext();
                var query = context.Set<T>().AsQueryable();
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return await query.FirstOrDefaultAsync(e => EF.Property<Guid>(e, "Id") == id);
            }

            public virtual IQueryable<T> GetAll(bool asNoTracking = false, params Expression<Func<T, object>>[] includes)
            {
                var context = _contextFactory.CreateDbContext();
                var query = context.Set<T>().AsQueryable();
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query;
            }

            public virtual IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool asNoTracking = false, params Expression<Func<T, object>>[] includes)
            {
                var context = _contextFactory.CreateDbContext();
                var query = context.Set<T>().Where(predicate);
                if (asNoTracking)
                {
                    query = query.AsNoTracking();
                }
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
                return query;
            }

            public virtual async Task DeleteAsync(T entity)
            {
                using var context = _contextFactory.CreateDbContext();
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

    }
}
