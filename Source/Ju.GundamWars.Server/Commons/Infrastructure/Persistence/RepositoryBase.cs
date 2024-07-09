using Ju.GundamWars.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

// NOTE: EF 自体は非同期にはしない https://learn.microsoft.com/ja-jp/ef/core/miscellaneous/async
public abstract class RepositoryBase<TDbContext, T>(TDbContext dbContext, ILogger logger) : IGw
    where TDbContext : DbContext
    where T : class
{

    protected TDbContext DbContext { get; } = dbContext;
    protected ILogger Logger { get; } = logger;
    protected DbSet<T> DbSet => DbContext.Set<T>();
    protected virtual IQueryable<T> Queryable => DbContext.Set<T>();


    protected (List<T>, int) SelectPaginatedListCore(Func<IQueryable<T>> selector, int page, int rowsCountPerPage)
    {
        if (rowsCountPerPage <= 0)
        {
            var all = selector().ToList();
            return (all, all.Count);
        }
        var rowsCount = selector().Count();
        var skip = (page - 1) * rowsCountPerPage;
        var list = selector().Skip(skip).Take(rowsCountPerPage).ToList();
        return (list, rowsCount);
    }

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

}
