using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotRepository(IDbContextFactory<GwDbContext> factory, ILogger<PilotRepository> logger)
    : TxnRepositoryBase<PilotDto>(factory, logger)
{

    protected override IQueryable<PilotDto> Queryable => DbSet.Include(e => e.TagMaps).OrderBy(e => e.Name).ThenBy(e => e.Id);

    //// 元々付いていた機体の関係を削除する
    //protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    //{
    //    var exMobileIds = dbContext.Set<Mobile>().Include(e => e.PilotMaps).Where(e => e.PilotMaps.Any(r => r.PilotId == id)).Select(e => e.Id).Distinct().ToList();
    //    dbContext.Set<MobilePilotMap>().RemoveRange(e => e.PilotId == id);
    //    return exMobileIds;
    //}

    //// 子を明示的に削除
    //protected override void DeleteRelations(GwDbContext dbContext, int id) =>
    //    dbContext.Set<PilotTagMap>().RemoveRange(e => e.PilotId == id);

    //// DbUpdateConcurrencyException
    //protected override void SetZeroToId(Pilot entity) =>
    //    entity.TagMaps.ForEach(e => e.PilotId = 0);

}
