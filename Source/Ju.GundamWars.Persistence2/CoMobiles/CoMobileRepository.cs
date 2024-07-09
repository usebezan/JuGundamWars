using Ju.GundamWars.Application.CoMobiles.Repositories;
using Ju.GundamWars.Domain.CoUnits.Entities;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence2.CoMobiles;

public class CoUnitRepository(IDbContextFactory<GwDbContext> factory, ILogger<CoUnitRepository> logger)
    : RepositoryBase2<CoUnit>(factory, logger), ICoUnitRepository
{

    public override CoUnit? SelectById(int id) =>
        Execute(dbContext => dbContext.IncludedCoUnits.FirstOrDefault(e => e.Id == id));

    public override List<CoUnit> SelectAll() =>
        Execute(dbContext => dbContext.IncludedCoUnits.OrderBy(e => e.Name).ThenBy(e => e.Id).ToList());

    // 元々付いていた機体の関係を削除する
    protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    {
        var exMobileIds = dbContext.Set<Mobile>().Include(e => e.CoUnits).Where(e => e.CoUnits.Any(r => r.CoUnitId == id)).Select(e => e.Id).Distinct().ToList();
        dbContext.Set<MobileCoUnit>().RemoveRange(e => e.CoUnitId == id);
        return exMobileIds;
    }

    // 子を明示的に削除
    protected override void DeleteRelations(GwDbContext dbContext, int id) =>
        dbContext.Set<CoUnitTagMap>().RemoveRange(e => e.CoUnitId == id);

    // DbUpdateConcurrencyException
    protected override void SetZeroToId(CoUnit entity) =>
        entity.TagMaps.ForEach(e => e.CoUnitId = 0);

}
