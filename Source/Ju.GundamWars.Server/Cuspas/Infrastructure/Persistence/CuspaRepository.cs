using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Ju.GundamWars.Server.Cuspas.Domain;
using Ju.GundamWars.Server.Cuspas.Domain.Gateway;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Cuspas.Infrastructure.Persistence;

public class CuspaRepository(IDbContextFactory<GwTxnDbContext> factory, ILogger<CuspaRepository> logger)
    : TxnRepository<CuspaEntity>(factory, logger), ICuspaRepository
{

    protected override IQueryable<CuspaEntity> Queryable => DbSet.Include(e => e.TagMaps).OrderBy(e => e.Id).ThenBy(e => e.Id);

    public override Task<CuspaEntity> UpdateAsync(CuspaEntity data) =>
        this.ExecuteAsync(Logger, () =>
        {
            using var txn = DbContext.Database.BeginTransaction();
            try
            {
                // 子を明示的に削除
                DbContext.Set<CuspaTagMapEntity>().RemoveRange(e => e.CuspaId == data.Id);
                DbContext.SaveChanges();

                var dbData = Find(data.Id) ?? throw new InvalidOperationException();
                DbContext.Entry(dbData).CurrentValues.SetValues(data);
                dbData.TagMaps.AddRange(data.TagMaps);
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
