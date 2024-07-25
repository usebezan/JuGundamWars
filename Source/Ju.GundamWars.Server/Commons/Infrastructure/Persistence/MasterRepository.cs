using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public class MasterRepository<T>(IDbContextFactory<GwMasterDbContext> factory, ILogger<MasterRepository<T>> logger)
    : RepositoryBase<GwMasterDbContext, T>(factory, logger), IMasterRepository<T>
    where T : class, IIdentifiable, IOrderable
{
    public override Task<List<T>> SelectAllAsync() =>
        this.ExecuteAsync(Logger, () => Queryable.OrderBy(e => e.Order).ToList());
}
