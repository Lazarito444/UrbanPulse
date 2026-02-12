using Microsoft.EntityFrameworkCore;
using UrbanPulse.Domain.Common.Pagination;
using UrbanPulse.Domain.Common.Repositories;
using UrbanPulse.Domain.Common.Specifications;
using UrbanPulse.Infrastructure.Contexts;

namespace UrbanPulse.Infrastructure.Repositories;

public class DataRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;

    public DataRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TEntity?> GetByIdAsync(object id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>().FindAsync([id], cancellationToken);
    }

    public async Task<TEntity?> GetByIdAsync(object[] composedKey, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<TEntity>().FindAsync(composedKey, cancellationToken);
    }

    public async Task<DataPage<TResult>> GetPagedAsync<TResult>(ISpecification<TEntity, TResult> spec, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> baseQuery = SpecificationEvaluator<TEntity, TResult>.GetFilteredQuery(_dbContext.Set<TEntity>().AsNoTracking(), spec);

        int totalCount = await baseQuery.CountAsync(cancellationToken);

        IQueryable<TResult> finalQuery = SpecificationEvaluator<TEntity, TResult>.GetFinalQuery(baseQuery, spec);
        List<TResult> data = await finalQuery.ToListAsync(cancellationToken);

        return new DataPage<TResult>(data, totalCount, spec.Skip / spec.Take + 1, spec.Take);
    }

    public async Task<List<TResult>> ListAsync<TResult>(ISpecification<TEntity, TResult> spec, CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> baseQuery = SpecificationEvaluator<TEntity, TResult>.GetFilteredQuery(_dbContext.Set<TEntity>().AsNoTracking(), spec);
        IQueryable<TResult> finalQuery = SpecificationEvaluator<TEntity, TResult>.GetFinalQuery(baseQuery, spec);
        return await finalQuery.ToListAsync(cancellationToken);
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().AddRange(entities);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().RemoveRange(entities);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void UpdateRange(IEnumerable<TEntity> entities)
    {
        _dbContext.Set<TEntity>().UpdateRange(entities);
    }
}
