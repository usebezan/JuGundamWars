using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Mobiles.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Mobiles;

public class MobileSSkillRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<MobileSSkillRepository> logger)
    : ReadOnlyRepositoryBase<MobileSSkill, GwMasterDbContext>(factory, logger), IMobileSSkillRepository
{

    public override List<MobileSSkill> SelectAll() => Execute(dbContext => dbContext.Set<MobileSSkill>().OrderBy(e => e.Order).ToList());

}
