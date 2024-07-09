using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Supports.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Supports;

public class SupportBadgeRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<SupportBadgeRepository> logger)
    : ReadOnlyRepositoryBase<SupportBadge, GwMasterDbContext>(factory, logger), ISupportBadgeRepository
{

    public override List<SupportBadge> SelectAll() => Execute(dbContext => dbContext.Set<SupportBadge>().OrderBy(e => e.Order).ToList());

}
