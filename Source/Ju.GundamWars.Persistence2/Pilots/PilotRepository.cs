using Ju.GundamWars.Application.Pilots.Repositories;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence2.Pilots;

public class PilotRepository(IDbContextFactory<GwDbContext> factory, ILogger<PilotRepository> logger)
    : RepositoryBase2<Pilot>(factory, logger), IPilotRepository
{

    public override Pilot? SelectById(int id) =>
        Execute(dbContext => dbContext.IncludedPilots.FirstOrDefault(e => e.Id == id));

    public override List<Pilot> SelectAll() =>
        Execute(dbContext => dbContext.IncludedPilots.OrderBy(e => e.Name).ThenBy(e => e.Id).ToList());

    // 元々付いていた機体の関係を削除する
    protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    {
        var exMobileIds = dbContext.Set<Mobile>().Include(e => e.PilotMaps).Where(e => e.PilotMaps.Any(r => r.PilotId == id)).Select(e => e.Id).Distinct().ToList();
        dbContext.Set<MobilePilotMap>().RemoveRange(e => e.PilotId == id);
        return exMobileIds;
    }

    // 子を明示的に削除
    protected override void DeleteRelations(GwDbContext dbContext, int id) =>
        dbContext.Set<PilotTagMap>().RemoveRange(e => e.PilotId == id);

    // DbUpdateConcurrencyException
    protected override void SetZeroToId(Pilot entity) =>
        entity.TagMaps.ForEach(e => e.PilotId = 0);

}
