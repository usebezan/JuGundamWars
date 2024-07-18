using Ju.GundamWars.BizMaster.Versionings.Domain;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.Systems.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Systems.Infrastructure.Persistence;

public class VersioningRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<VersioningRepository> logger)
    : RepositoryBase<GwMasterDbContext, VersioningEntity>(factory, logger), IVersioningRepository
{
}
