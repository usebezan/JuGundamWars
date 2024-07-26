using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.CoMobiles.Domain;
using Ju.GundamWars.Server.CoMobiles.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.CoMobiles.Infrastructure.Persistence;

public class CoMobileRepository(IDbContextFactory<GwTxnDbContext> factory, ILogger<CoMobileRepository> logger)
    : TxnRepository<CoMobileEntity>(factory, logger), ICoMobileRepository
{

    protected override IQueryable<CoMobileEntity> Queryable => DbSet.Include(e => e.TagLinks).OrderBy(e => e.Name).ThenBy(e => e.Id);

    public override Task<CoMobileEntity> UpdateAsync(CoMobileEntity data) =>
        this.ExecuteAsync(Logger, () =>
        {
            using var txn = DbContext.Database.BeginTransaction();
            try
            {
                // 子を明示的に削除
                DbContext.Set<CoMobileTagLinkEntity>().RemoveRange(e => e.CoMobileId == data.Id);
                DbContext.SaveChanges();

                var dbData = Find(data.Id) ?? throw new InvalidOperationException();
                DbContext.Entry(dbData).CurrentValues.SetValues(data);
                dbData.TagLinks.AddRange(data.TagLinks);
                var result = DbSet.Update(dbData).Entity;
                DbContext.SaveChanges();
                txn.Commit();
                return result;
            }
            catch
            {
                txn.Rollback();
                throw;
            }
        });

    //// 元々付いていた機体の関係を削除する
    //protected override List<int> DeleteExMobileRelations(GwDbContext dbContext, int id)
    //{
    //    var exMobileIds = dbContext.Set<Mobile>().Include(e => e.CoMobiles).Where(e => e.CoMobiles.Any(r => r.CoMobileId == id)).Select(e => e.Id).Distinct().ToList();
    //    dbContext.Set<MobileCoMobile>().RemoveRange(e => e.CoMobileId == id);
    //    return exMobileIds;
    //}

}
