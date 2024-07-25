using Ju.GundamWars.Commons.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

// NOTE: EF 自体は非同期にはしない https://learn.microsoft.com/ja-jp/ef/core/miscellaneous/async
public abstract class RepositoryBase<TDbContext, T>(IDbContextFactory<TDbContext> factory, ILogger logger) : IGw
    where TDbContext : DbContext
    where T : class, IIdentifiable
{

    protected IDbContextFactory<TDbContext> Factory { get; } = factory;
    protected TDbContext DbContext { get; } = factory.CreateDbContext();
    protected ILogger Logger { get; } = logger;
    protected DbSet<T> DbSet => DbContext.Set<T>();
    protected virtual IQueryable<T> Queryable => DbContext.Set<T>();


    #region Select

    public Task<T?> SelectByIdAsync(long id) =>
        this.ExecuteAsync(Logger, () => Find(id));

    public virtual Task<List<T>> SelectAllAsync() =>
        this.ExecuteAsync(Logger, () => Queryable.ToList());

    #endregion

    #region Insert

    public Task<T> InsertAsync(T data) =>
        this.ExecuteAsync(Logger, () =>
        {
            var result = DbSet.Add(data).Entity;
            DbContext.SaveChanges();
            return result;
        });

    #endregion

    #region Update

    public virtual Task<T> UpdateAsync(T data) =>
        UpdateAsync(() => Find(data.Id), data);

    protected Task<T> UpdateAsync(Func<T?> selector, T data) =>
        this.ExecuteAsync(Logger, () =>
        {
            var dbData = selector() ?? throw new InvalidOperationException();
            DbContext.Entry(dbData).CurrentValues.SetValues(data);
            var result = DbSet.Update(dbData).Entity;
            DbContext.SaveChanges();
            return result;
        });

    #endregion

    #region Delete

    public Task<T> DeleteAsync(long id) =>
        DeleteAsync(() => Find(id));

    protected Task<T> DeleteAsync(Func<T?> selector) =>
        this.ExecuteAsync(Logger, () =>
        {
            var dbData = selector() ?? throw new InvalidOperationException();
            var result = DbSet.Remove(dbData).Entity;
            DbContext.SaveChanges();
            return result;
        });

    #endregion

    protected T? Find(long id) =>
        Queryable.FirstOrDefault(e => e.Id == id);

}
