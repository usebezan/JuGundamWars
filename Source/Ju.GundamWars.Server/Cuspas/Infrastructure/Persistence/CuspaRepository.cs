using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaRepository(IDbContextFactory<GwDbContext> factory, ILogger<CuspaRepository> logger)
    : TxnRepositoryBase<CuspaDto>(factory, logger)
{

    protected override IQueryable<CuspaDto> Queryable => DbSet.Include(e => e.TagMaps).OrderBy(e => e.BoostStatus).ThenBy(e => e.Kind).ThenBy(e => e.Id);

    //// 元々付いていた機体の関係を削除する
    //protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    //{
    //    var exMobileIds = dbContext.Set<Mobile>().Include(e => e.Cuspas).Where(e => e.Cuspas.Any(r => r.CuspaId == id)).Select(e => e.Id).Distinct().ToList();
    //    dbContext.Set<MobileCuspa>().RemoveRange(e => e.CuspaId == id);
    //    return exMobileIds;
    //}

    //// 子を明示的に削除
    //protected override void DeleteRelations(GwDbContext dbContext, int id) =>
    //    dbContext.Set<CuspaTagMap>().RemoveRange(e => e.CuspaId == id);

    //// DbUpdateConcurrencyException
    //protected override void SetZeroToId(Cuspa entity) =>
    //    entity.TagMaps.ForEach(e => e.CuspaId = 0);

}
