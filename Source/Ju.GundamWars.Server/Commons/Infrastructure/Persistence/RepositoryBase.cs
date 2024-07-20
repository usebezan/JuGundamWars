using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

// NOTE: EF 自体は非同期にはしない https://learn.microsoft.com/ja-jp/ef/core/miscellaneous/async
public abstract class RepositoryBase<TDbContext, T>(IDbContextFactory<TDbContext> factory, ILogger logger) : IGw, IByIdGateway<T>
    where TDbContext : DbContext
    where T : class, IIdentify
{

    protected IDbContextFactory<TDbContext> Factory { get; } = factory;
    protected TDbContext DbContext { get; } = factory.CreateDbContext();
    protected ILogger Logger { get; } = logger;
    protected DbSet<T> DbSet => DbContext.Set<T>();
    protected virtual IQueryable<T> Queryable => DbContext.Set<T>();


    #region Select

    public Task<T?> SelectByIdAsync(long id) =>
        this.ExecuteAsync(Logger, () => Find(id));

    public abstract Task<List<T>> SelectAllAsync();

    #endregion

    #region Insert

    public Task<T> InsertAsync(T data) =>
        this.ExecuteAsync(Logger, () =>
        {
            var result = InsertCore(data);
            DbContext.SaveChanges();
            return result;
        });

    protected T InsertCore(T data)
    {
        return DbSet.Add(data).Entity;
    }

    #endregion

    #region Update

    public Task<T> UpdateAsync(T data) =>
        UpdateAsync(() => Find(data.Id), data);

    protected Task<T> UpdateAsync(Func<T?> selector, T data) =>
        this.ExecuteAsync(Logger, () =>
        {
            var result = UpdateCore(selector, data);
            DbContext.SaveChanges();
            return result;
        });

    protected T UpdateCore(Func<T?> selector, T data)
    {
        // TODO: Exception
        var dbData = selector() ?? throw new InvalidOperationException();
        DbContext.Entry(dbData).CurrentValues.SetValues(data);
        return DbSet.Update(dbData).Entity;
    }

    #endregion

    #region Delete

    public Task<T> DeleteByIdAsync(long id) =>
        DeleteAsync(() => Find(id));

    protected Task<T> DeleteAsync(Func<T?> selector) =>
        this.ExecuteAsync(Logger, () =>
        {
            var result = DeleteCore(selector);
            DbContext.SaveChanges();
            return result;
        });

    protected T DeleteCore(Func<T?> selector)
    {
        // TODO: Exception
        var dbData = selector() ?? throw new InvalidOperationException();
        return DbSet.Remove(dbData).Entity;
    }

    #endregion

    protected T? Find(long id) =>
        Queryable.FirstOrDefault(e => e.Id == id);

}
