using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.Pilots.Domain;
using Ju.GundamWars.Server.Pilots.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Pilots.Infrastructure.Persistence;

public class PilotRepository(IDbContextFactory<GwTxnDbContext> factory, ILogger<PilotRepository> logger)
    : TxnRepository<PilotEntity>(factory, logger), IPilotRepository
{

    protected override IQueryable<PilotEntity> Queryable => DbSet.Include(e => e.PilotSlotAbilities).Include(e => e.TagLinks).OrderBy(e => e.Name).ThenBy(e => e.Id);

    public override Task<PilotEntity> UpdateAsync(PilotEntity data) =>
        this.ExecuteAsync(Logger, () =>
        {
            using var txn = DbContext.Database.BeginTransaction();
            try
            {
                // 子を明示的に削除
                DbContext.Set<PilotSlotAbilityEntity>().RemoveRange(e => e.PilotId == data.Id);
                DbContext.Set<PilotTagLinkEntity>().RemoveRange(e => e.PilotId == data.Id);
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
