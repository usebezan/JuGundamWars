using Ju.GundamWars.Application.Versionings.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Versionings;

public class VersioningRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<VersioningRepository> logger)
    : ReadOnlyRepositoryBase<Versioning, GwMasterDbContext>(factory, logger), IVersioningRepository
{

    public override List<Versioning> SelectAll() => throw new NotImplementedException();

}
