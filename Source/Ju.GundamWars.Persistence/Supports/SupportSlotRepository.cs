using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Domain.Supports.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence.Supports;

public class SupportSlotRepository(IDbContextFactory<GwMasterDbContext> factory, ILogger<SupportSlotRepository> logger)
    : ReadOnlyRepositoryBase<SupportSlot, GwMasterDbContext>(factory, logger), ISupportSlotRepository
{

    public override List<SupportSlot> SelectAll() => Execute(dbContext => dbContext.Set<SupportSlot>().OrderBy(e => e.Order).ToList());

}
