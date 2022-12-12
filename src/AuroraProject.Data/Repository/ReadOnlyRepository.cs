using AuroraProject.Core.Data;
using AuroraProject.Core.Specifications;
using AuroraProject.Core.Validations;
using Microsoft.EntityFrameworkCore;

namespace AuroraProject.Data.Repository
{
    public class ReadOnlyRepository<T> : IReadOnlyAsyncRepository<T> where T : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<T> _dbSet;

        public ReadOnlyRepository(DbContext context)
        {
            ExceptionValidate.EqualNull(context, $"Parameter: @context Contexto Não pode ser nulo.");

            _dbContext = context;
            _dbSet = _dbContext.Set<T>();

            ExceptionValidate.EqualNull(_dbSet, $"Parameter: @_dbSet não encontrado no contexto.");

        }

        public async Task<bool> AnyAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.AsNoTracking().AnyAsync(cancellationToken);
        }

        public async Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.CountAsync(cancellationToken);
        }

        public async Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.CountAsync(cancellationToken);
        }

        public async Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.AsNoTracking().FirstAsync(cancellationToken);
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            var result = await specificationResult.AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            return result;
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default)
        {
            var specificationResult = ApplySpecification(spec);
            return await specificationResult.AsNoTracking().ToListAsync(cancellationToken);
        }
        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            var evaluator = new EvaluatorOfSpecification<T>();
            return evaluator.GetQuery(_dbSet.AsQueryable(), spec);
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
