using Microsoft.EntityFrameworkCore;
using PortfolioProjets.API.Data;
using PortfolioProjets.API.Entities;
using PortfolioProjets.API.Interfaces;

namespace PortfolioProjets.API.Services
{
   
        public class AsyncRepository<T> : IAsyncRepository<T> where T : BaseEntity
        {
            protected readonly ProjetsContext _dbContext;

            public AsyncRepository(ProjetsContext dbContext)
            {
                _dbContext = dbContext;
            }
            public async Task<T> AddAsync(T entity)
            {
                await _dbContext.Set<T>().AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }

            public async Task DeleteAsync(T entity)
            {
                _dbContext.Set<T>().Remove(entity);
                await _dbContext.SaveChangesAsync();
            }

            public async Task EditAsync(T entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }

            public virtual async Task<T?> GetByIdAsync(Guid id)
            {
                return await _dbContext.Set<T>().AsNoTracking().SingleOrDefaultAsync(t => t.Id == id);
            }

            public virtual async Task<IEnumerable<T>> ListAsync()
            {
                return await _dbContext.Set<T>().ToListAsync();
            }

            public virtual async Task<IEnumerable<T>> ListAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
            {
                return await _dbContext.Set<T>()
                    .Where(predicate)
                    .ToListAsync();
            }
        }
    
}
