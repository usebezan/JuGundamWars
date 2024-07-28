using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.Supports.Domain;
using Ju.GundamWars.Server.Supports.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Supports.Infrastructure.Persistence;

public class SupportRepository(IDbContextFactory<GwTxnDbContext> factory, ILogger<SupportRepository> logger)
    : TxnRepository<SupportEntity>(factory, logger), ISupportRepository
{

    protected override IQueryable<SupportEntity> Queryable => DbSet
        .Include(e => e.SupportLimitedSerialLinks)
        .Include(e => e.SupportSlotBadges)
        .Include(e => e.TagLinks)
        .OrderBy(e => e.Name).ThenBy(e => e.Id);

    public override Task<SupportEntity> UpdateAsync(SupportEntity data) =>
        this.ExecuteAsync(Logger, () =>
        {
            using var txn = DbContext.Database.BeginTransaction();
            try
            {
                // 子を明示的に削除
                DbContext.Set<SupportLimitedSerialLinkEntity>().RemoveRange(e => e.SupportId == data.Id);
                DbContext.Set<SupportSlotBadgeEntity>().RemoveRange(e => e.SupportId == data.Id);
                DbContext.Set<SupportTagLinkEntity>().RemoveRange(e => e.SupportId == data.Id);
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

}
