using Ju.GundamWars.Application.Supports.Repositories;
using Ju.GundamWars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence2.Supports;

public class SupportRepository(IDbContextFactory<GwDbContext> factory, ILogger<SupportRepository> logger)
    : RepositoryBase2<Support>(factory, logger), ISupportRepository
{

    public override Support? SelectById(int id) =>
        Execute(dbContext => dbContext.IncludedSupports.FirstOrDefault(e => e.Id == id));

    public override List<Support> SelectAll() =>
        Execute(dbContext => dbContext.IncludedSupports.OrderBy(e => e.Name).ThenBy(e => e.Id).ToList());

    // 元々付いていた機体の関係を削除する
    protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    {
        var exMobileIds = dbContext.Set<Mobile>().Include(e => e.Supports).Where(e => e.Supports.Any(r => r.SupportId == id)).Select(e => e.Id).Distinct().ToList();
        dbContext.Set<MobileSupport>().RemoveRange(e => e.SupportId == id);
        return exMobileIds;
    }

    // 子を明示的に削除
    protected override void DeleteRelations(GwDbContext dbContext, int id)
    {
        dbContext.Set<SupportLimitedSerialMap>().RemoveRange(e => e.SupportId == id);
        dbContext.Set<SupportTagMap>().RemoveRange(e => e.SupportId == id);
        dbContext.Set<SupportSlotBadge>().RemoveRange(e => e.SupportId == id);
    }

    // DbUpdateConcurrencyException
    protected override void SetZeroToId(Support entity)
    {
        entity.LimitedSerialMaps.ForEach(e => e.SupportId = 0);
        entity.TagMaps.ForEach(e => e.SupportId = 0);
        entity.SlotBadges.ForEach(e => e.SupportId = 0);
    }

}
