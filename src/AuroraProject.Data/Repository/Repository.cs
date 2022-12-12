using AuroraProject.Core.Data;
using AuroraProject.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace AuroraProject.Data.Repository
{
    public class Repository<T> : ReadOnlyRepository<T>, IAsyncRepository<T> where T : Entity
    {
        public Repository(DbContext context) : base(context)
        {
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbSet.AddAsync(entity);
            await SaveChanges(cancellationToken);
            return entity;
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Remove(entity);
            await SaveChanges(cancellationToken);

        }

        public async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _dbSet.AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _dbSet.Update(entity);
            await SaveChanges(cancellationToken);
        }

        private async Task SaveChanges(CancellationToken cancellationToken = default)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}