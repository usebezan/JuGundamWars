using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportRepository(IDbContextFactory<GwDbContext> factory, ILogger<SupportRepository> logger)
    : TxnRepositoryBase<SupportDto>(factory, logger)
{

    protected override IQueryable<SupportDto> Queryable => DbSet.Include(e => e.LimitedSerialMaps).Include(e => e.TagMaps).Include(e => e.SlotBadges).OrderBy(e => e.Name).ThenBy(e => e.Id);

    //// 元々付いていた機体の関係を削除する
    //protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    //{
    //    var exMobileIds = dbContext.Set<Mobile>().Include(e => e.Supports).Where(e => e.Supports.Any(r => r.SupportId == id)).Select(e => e.Id).Distinct().ToList();
    //    dbContext.Set<MobileSupport>().RemoveRange(e => e.SupportId == id);
    //    return exMobileIds;
    //}

    //// 子を明示的に削除
    //protected override void DeleteRelations(GwDbContext dbContext, int id)
    //{
    //    dbContext.Set<SupportLimitedSerialMap>().RemoveRange(e => e.SupportId == id);
    //    dbContext.Set<SupportTagMap>().RemoveRange(e => e.SupportId == id);
    //    dbContext.Set<SupportSlotBadge>().RemoveRange(e => e.SupportId == id);
    //}

    //// DbUpdateConcurrencyException
    //protected override void SetZeroToId(Support entity)
    //{
    //    entity.LimitedSerialMaps.ForEach(e => e.SupportId = 0);
    //    entity.TagMaps.ForEach(e => e.SupportId = 0);
    //    entity.SlotBadges.ForEach(e => e.SupportId = 0);
    //}

}
