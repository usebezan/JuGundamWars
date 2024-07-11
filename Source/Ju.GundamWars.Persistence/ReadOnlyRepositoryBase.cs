using Ju.GundamWars.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Ju.GundamWars.Persistence;

public abstract class ReadOnlyRepositoryBase<TEntity, TDbContext>(IDbContextFactory<TDbContext> factory, ILogger logger) : IReadOnlyRepository<TEntity>
    where TEntity : class, IIdentify
    where TDbContext : DbContext
{

    protected TResult Execute<TResult>(Func<TDbContext, TResult> executor, [CallerMemberName] string? callerMemberName = null)
    {
        logger.LogDebug("{callerMemberName} start.", callerMemberName);
        using var dbContext = factory.CreateDbContext();
        var result = executor(dbContext);
        logger.LogDebug("{callerMemberName} end.", callerMemberName);
        return result;
    }

    public virtual TEntity? Find(params object?[]? keyValues) => Execute(dbContext => dbContext.Set<TEntity>().Find(keyValues));
    public virtual TEntity? SelectById(int id) => Execute(dbContext => dbContext.Set<TEntity>().FirstOrDefault(e => e.Id == id));
    public abstract List<TEntity> SelectAll();

}
