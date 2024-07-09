using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Xosmos.Domain;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public abstract class ByIdFactoryRepositoryBase<TDbContext, T>(
    IDbContextFactory<TDbContext> factory,
    ILogger logger) :
        ByIdRepositoryBase<TDbContext, T>(factory.CreateDbContext(), logger)
    where TDbContext : DbContext
    where T : class, IIdentify
{
    protected IDbContextFactory<TDbContext> Factory { get; } = factory;
}
