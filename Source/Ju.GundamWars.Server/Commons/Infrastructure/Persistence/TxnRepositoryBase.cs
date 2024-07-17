using Ju.GundamWars.Commons.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public abstract class TxnRepositoryBase<T>(IDbContextFactory<GwTxnDbContext> factory, ILogger<TxnRepositoryBase<T>> logger)
    : RepositoryBase<GwTxnDbContext, T>(factory, logger), ITxnRepository<T>
    where T : class, IIdentify
{
    public Task<List<T>> SelectAllAsync() =>
        this.ExecuteAsync(Logger, () => Queryable.ToList());
}
