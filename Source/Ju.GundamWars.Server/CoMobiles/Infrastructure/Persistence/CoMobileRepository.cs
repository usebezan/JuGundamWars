using Ju.GundamWars.Server.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileRepository(IDbContextFactory<GwTxnDbContext> factory, ILogger<CoMobileRepository> logger)
    : TxnRepository<CoMobileEntity>(factory, logger), ICoMobileRepository
{

    protected override IQueryable<CoMobileEntity> Queryable => DbSet.Include(e => e.TagMaps).OrderBy(e => e.Name).ThenBy(e => e.Id);

    //// 元々付いていた機体の関係を削除する
    //protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    //{
    //    var exMobileIds = dbContext.Set<Mobile>().Include(e => e.CoMobiles).Where(e => e.CoMobiles.Any(r => r.CoMobileId == id)).Select(e => e.Id).Distinct().ToList();
    //    dbContext.Set<MobileCoMobile>().RemoveRange(e => e.CoMobileId == id);
    //    return exMobileIds;
    //}

    //// 子を明示的に削除
    //protected override void DeleteRelations(GwDbContext dbContext, int id) =>
    //    dbContext.Set<CoMobileTagMap>().RemoveRange(e => e.CoMobileId == id);

    //// DbUpdateConcurrencyException
    //protected override void SetZeroToId(CoMobile entity) =>
    //    entity.TagMaps.ForEach(e => e.CoMobileId = 0);

}
