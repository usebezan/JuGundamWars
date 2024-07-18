using Ju.GundamWars.BizMaster.Versionings.Domain;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Versionings.Infrastructure.Persistence;

public class VersioningRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<VersioningRepository> logger)
    : RepositoryBase<GwMasterDbContext, VersioningEntity>(factory, logger), IVersioningGateway<VersioningEntity>
{
}
