using System.Linq.Expressions;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;

public interface IAsyncRepository<T> : IQuery<T> where T : Entity
{
    Task<T?> GetAsync(Expression<Func<T, bool>> predicate);

    Task<IPaginate<T>> GetListAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0, int size = 10, bool enableTracking = true,
        CancellationToken cancellationToken = default);

    Task<IPaginate<T>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        int index = 0, int size = 10, bool enableTracking = true,
        CancellationToken cancellationToken = default);
    Task<T> AddAsync(T entity);
    Task<int> AddAsync(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task<int> AddOrUpdateAsync(T entity);
    Task<int> DeleteAsync(T entity);
    Task<int> DeleteAsync(Guid id);
    Task<bool> DeleteRangeAsync(Expression<Func<T, bool>> predicate);

    Task BulkDeleteById(IEnumerable<Guid> ids);
    Task BulkDelete(Expression<Func<T, bool>> predicate);
    Task BulkDelete(IEnumerable<T> entities);
    Task BulkUpdate(IEnumerable<T> entities);
    Task BulkAdd(IEnumerable<T> entities);
    
}