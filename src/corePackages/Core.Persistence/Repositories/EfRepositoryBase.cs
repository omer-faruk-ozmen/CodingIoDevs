using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Core.Persistence.Repositories;
public class EfRepositoryBase<TEntity, TContext> : IAsyncRepository<TEntity>, IRepository<TEntity> where TEntity : Entity where TContext : DbContext
{

    protected TContext Context { get; }
    protected DbSet<TEntity> Entity => Context.Set<TEntity>();

    public EfRepositoryBase(TContext context)
    {
        Context = context ?? throw new ArgumentException(nameof(Context));
    }


    #region QueryMethods
    public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
    {
        return Context.Set<TEntity>().FirstOrDefault(predicate);
    }

    public IPaginate<TEntity> GetList(Expression<Func<TEntity, bool>>? predicate = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
        int index = 0, int size = 10,
        bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return orderBy(queryable).ToPaginate(index, size);
        return queryable.ToPaginate(index, size);
    }

    public IPaginate<TEntity> GetListByDynamic(Dynamic.Dynamic dynamic,
        Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
            include = null, int index = 0, int size = 10,
        bool enableTracking = true)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return queryable.ToPaginate(index, size);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate)
    {
        return await Context.Set<TEntity>().FirstOrDefaultAsync(predicate);
    }

    public async Task<IPaginate<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null,
                                                       Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy =
                                                           null,
                                                       Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>?
                                                           include = null,
                                                       int index = 0, int size = 10, bool enableTracking = true,
                                                       CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query();
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        if (predicate != null) queryable = queryable.Where(predicate);
        if (orderBy != null)
            return await orderBy(queryable).ToPaginateAsync(index, size, 0, cancellationToken);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public async Task<IPaginate<TEntity>> GetListByDynamicAsync(Dynamic.Dynamic dynamic,
                                                                Func<IQueryable<TEntity>,
                                                                        IIncludableQueryable<TEntity, object>>?
                                                                    include = null,
                                                                int index = 0, int size = 10,
                                                                bool enableTracking = true,
                                                                CancellationToken cancellationToken = default)
    {
        IQueryable<TEntity> queryable = Query().AsQueryable().ToDynamic(dynamic);
        if (!enableTracking) queryable = queryable.AsNoTracking();
        if (include != null) queryable = include(queryable);
        return await queryable.ToPaginateAsync(index, size, 0, cancellationToken);
    }

    public IQueryable<TEntity> Query()
    {
        return Context.Set<TEntity>();
    }

    #endregion

    #region InsertMethods

    public TEntity Add(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        Context.SaveChanges();
        return entity;
    }

    public int Add(IEnumerable<TEntity> entities)
    {
        if (entities != null && !entities.Any())
            return 0;

        Entity.AddRange();
        return Context.SaveChanges();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Added;
        await Context.SaveChangesAsync();
        return entity;
    }

    public async Task<int> AddAsync(IEnumerable<TEntity> entities)
    {
        await Context.AddRangeAsync(entities);

        return await Context.SaveChangesAsync();
    }

    #endregion

    #region UpdateMethods
    public TEntity Update(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        Context.SaveChanges();
        return entity;
    }

    public int AddOrUpdate(TEntity entity)
    {
        if (Entity.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
            Context.Update(entity);

        return Context.SaveChanges();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
        return entity;
    }

    public Task<int> AddOrUpdateAsync(TEntity entity)
    {
        if (Entity.Local.Any(i => EqualityComparer<Guid>.Default.Equals(i.Id, entity.Id)))
            Context.Update(entity);

        return Context.SaveChangesAsync();
    }

    #endregion

    #region DeleteMethods

    public int Delete(TEntity entity)
    {
        if (Context.Entry(entity).State == EntityState.Deleted)
            Entity.Attach(entity);

        Entity.Remove(entity);
        return Context.SaveChanges();
    }

    public int Delete(Guid id)
    {
        var entity = Entity.Find(id);
        return Delete(entity);
    }

    public bool DeleteRange(Expression<Func<TEntity, bool>> predicate)
    {
        Context.RemoveRange(Entity.Where(predicate));
        return Context.SaveChanges() > 0;
    }

    public Task<int> DeleteAsync(TEntity entity)
    {
        if (Context.Entry(entity).State == EntityState.Deleted)
        {
            Entity.Attach(entity);
        }

        Entity.Remove(entity);
        return Context.SaveChangesAsync();
    }

    public Task<int> DeleteAsync(Guid id)
    {
        var entity = Entity.Find(id);
        return DeleteAsync(entity);
    }

    public async Task<bool> DeleteRangeAsync(Expression<Func<TEntity, bool>> predicate)
    {
        Context.RemoveRange(Entity.Where(predicate));
        return await Context.SaveChangesAsync() > 0;
    }

    #endregion

    #region BulkMethods

    public Task BulkDeleteById(IEnumerable<Guid> ids)
    {
        if (ids != null && !ids.Any())
            return Task.CompletedTask;

        Context.RemoveRange(Entity.Where(i => ids.Contains(i.Id)));
        return Context.SaveChangesAsync();
    }

    public Task BulkDelete(Expression<Func<TEntity, bool>> predicate)
    {
        Context.RemoveRange(Entity.Where(predicate));
        return Context.SaveChangesAsync();
    }

    public Task BulkDelete(IEnumerable<TEntity> entities)
    {

        if (entities != null && !entities.Any())
            return Task.CompletedTask;

        Entity.RemoveRange(entities);
        return Context.SaveChangesAsync();
    }

    public Task BulkUpdate(IEnumerable<TEntity> entities)
    {
        if (entities != null && !entities.Any())
            return Task.CompletedTask;

        foreach (var entity in entities!)
        {
            Entity.Update(entity);
        }

        return Context.SaveChangesAsync();
    }

    public async Task BulkAdd(IEnumerable<TEntity> entities)
    {
        if (entities != null && !entities.Any())
            await Task.CompletedTask;

        await Entity.AddRangeAsync(entities);

        await Context.SaveChangesAsync();
    }

    #endregion

}
