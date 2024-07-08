using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Pilots.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Pilots;

public class PilotAbilityRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<PilotAbilityRepository> logger)
    : ReadOnlyRepositoryBase<PilotAbility, GwMasterDbContext>(factory, logger), IPilotAbilityRepository
{

    public override List<PilotAbility> SelectAll() => Execute(dbContext => dbContext.Set<PilotAbility>().OrderBy(e => e.Order).ToList());

}
