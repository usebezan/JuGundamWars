using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Pilots.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Pilots;

public class PilotSkillRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<PilotSkillRepository> logger)
    : ReadOnlyRepositoryBase<PilotSkill, GwMasterDbContext>(factory, logger), IPilotSkillRepository
{

    public override List<PilotSkill> SelectAll() => Execute(dbContext => dbContext.Set<PilotSkill>().OrderBy(e => e.Order).ToList());

}
