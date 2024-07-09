using Ju.GundamWars.Domain.Common.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xosmos.Domain;

namespace Ju.GundamWars.Server.Infrastructure.Persistence.Common;

// NOTE: Insert は Base
public abstract class ByIdRepositoryBase<TDbContext, T>(
    TDbContext dbContext,
    ILogger logger) :
        RepositoryBase<TDbContext, T>(dbContext, logger), IByIdGateway<T>
    where TDbContext : DbContext
    where T : class, IIdentify
{
    public Task<T?> SelectByIdAsync(long id) => this.ExecuteAsync(Logger, () => Find(id));
    public Task<T> UpdateAsync(T data) => UpdateAsync(() => Find(data.Id), data);
    public Task<T> DeleteByIdAsync(long id) => DeleteAsync(() => Find(id));
    protected T? Find(long id) => Queryable.FirstOrDefault(e => e.Id == id);
}
