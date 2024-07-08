using Ju.GundamWars.Application.Mobiles.Repositories;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence2.Mobiles;

public class MobileRepository(IDbContextFactory<GwDbContext> factory, ILogger<MobileRepository> logger)
    : RepositoryBase<Mobile>(factory, logger), IMobileRepository
{

    public override Mobile? SelectById(int id) =>
        Execute(dbContext => dbContext.IncludedMobiles.FirstOrDefault(e => e.Id == id));

    public override List<Mobile> SelectAll() =>
        Execute(dbContext => dbContext.IncludedMobiles.OrderBy(e => e.Name).ThenBy(e => e.Id).ToList());

    public override Task<(Mobile self, List<Mobile>? exes)> InsertAsync(Mobile entity) =>
        SaveChangesAsync(dbContext =>
        {
            var exMobileIds = DeleteExMobileRelations(dbContext, entity);
            SetZeroToId(entity);
            return (dbContext.Set<Mobile>().Add(entity).Entity, exMobileIds);
        });

    public override Task<(Mobile self, List<Mobile>? exes)> UpdateAsync(Mobile entity) =>
        SaveChangesAsync(dbContext =>
        {
            var exMobileIds = DeleteExMobileRelations(dbContext, entity);
            RemoveRelations(dbContext, entity.Id);
            SetZeroToId(entity);
            return (dbContext.Set<Mobile>().Update(entity).Entity, exMobileIds);
        });

    public override Task<(Mobile self, List<Mobile>? exes)> DeleteByIdAsync(int id) =>
        SaveChangesAsync(dbContext =>
        {
            // 外す MobileId を抽出
            var exMobileIds = dbContext.Set<Mobile>()
                .Include(e => e.PairMaps)
                .Where(e => e.Id != id)
                .Where(e => e.PairMaps.Any(r => r.PairId == id))
                .Select(e => e.Id).Distinct().ToList();
            // 外す Mobile の紐付けを削除
            dbContext.Set<MobilePairMap>().RemoveRange(e => e.PairId == id);
            RemoveRelations(dbContext, id);
            return (dbContext.Set<Mobile>().Remove(e => e.Id == id).Entity, exMobileIds);
        });

    // 元々付いていた機体の関係を削除する
    // Pilot、Cuspa は外さない
    private List<int> DeleteExMobileRelations(GwDbContext dbContext, Mobile entity)
    {
        var pairIds = entity.PairMaps.Select(e => e.PairId).ToArray();
        var supportIds = entity.Supports.Select(e => e.SupportId).ToArray();
        var coMobileIds = entity.CoMobiles.Select(e => e.CoMobileId).ToArray();
        // 外す MobileId を抽出
        var exMobileIds = dbContext.Set<Mobile>()
            .Include(e => e.PairMaps)
            .Include(e => e.Supports)
            .Include(e => e.CoMobiles)
            .Where(e => e.Id != entity.Id)
            .Where(e =>
                e.PairMaps.Any(r => pairIds.Contains(r.PairId)) ||
                e.Supports.Any(r => supportIds.Contains(r.SupportId)) ||
                e.CoMobiles.Any(r => coMobileIds.Contains(r.CoMobileId)))
            .Select(e => e.Id).Distinct().ToList();
        // 外す Mobile の紐付けを削除
        dbContext.Set<MobilePairMap>().RemoveRange(e => pairIds.Contains(e.PairId));
        dbContext.Set<MobileSupport>().RemoveRange(e => supportIds.Contains(e.SupportId));
        dbContext.Set<MobileCoMobile>().RemoveRange(e => coMobileIds.Contains(e.CoMobileId));
        return exMobileIds;
    }

    // 子を明示的に削除
    private void RemoveRelations(GwDbContext dbContext, int id)
    {
        dbContext.Set<MobilePairMap>().RemoveRange(e => e.MobileId == id);
        dbContext.Set<MobileSubSerialMap>().RemoveRange(e => e.MobileId == id);
        dbContext.Set<MobileTagMap>().RemoveRange(t => t.MobileId == id);
        dbContext.Set<MobilePilotMap>().RemoveRange(p => p.MobileId == id);
        dbContext.Set<MobileCuspa>().RemoveRange(e => e.MobileId == id);
        dbContext.Set<MobileSupport>().RemoveRange(e => e.MobileId == id);
        dbContext.Set<MobileCoMobile>().RemoveRange(e => e.MobileId == id);
    }

    // DbUpdateConcurrencyException
    private void SetZeroToId(Mobile entity)
    {
        entity.PairMaps.ForEach(e => e.MobileId = 0);
        entity.SubSerialMaps.ForEach(e => e.MobileId = 0);
        entity.TagMaps.ForEach(e => e.MobileId = 0);
        entity.PilotMaps.ForEach(e => e.MobileId = 0);
        entity.Cuspas.ForEach(e => e.MobileId = 0);
        entity.Supports.ForEach(e => e.MobileId = 0);
        entity.CoMobiles.ForEach(e => e.MobileId = 0);
    }

}
