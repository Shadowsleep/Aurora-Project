using AuroraProject.Core.Specifications;

namespace AuroraProject.Core.Data
{
    public interface IReadOnlyAsyncRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CountAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> CountAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> FirstAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<T> FirstOrDefaultAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="spec"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> AnyAsync(ISpecification<T> spec, CancellationToken cancellationToken = default);

    }
}