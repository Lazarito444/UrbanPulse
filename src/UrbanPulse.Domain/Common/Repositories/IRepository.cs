using UrbanPulse.Domain.Common.Pagination;
using UrbanPulse.Domain.Common.Specifications;

namespace UrbanPulse.Domain.Common.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    Task<DataPage<TResult>> GetPagedAsync<TResult>(ISpecification<TEntity, TResult> spec, CancellationToken cancellationToken = default);
    Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> spec, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default);
    Task<TEntity?> GetByIdAsync(object[] composedKey, CancellationToken cancellationToken = default);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
    void AddRange(IEnumerable<TEntity> entities);
    void UpdateRange(IEnumerable<TEntity> entities);
    void DeleteRange(IEnumerable<TEntity> entities);
}
