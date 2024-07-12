using Ju.GundamWars.BizTxn.Tags.Domain.Dto;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Tags.Infrastructure.Persistence;

public class TagRepository(IDbContextFactory<GwDbContext> factory, ILogger<TagRepository> logger)
    : TxnRepositoryBase<TagDto>(factory, logger)
{
    protected override IQueryable<TagDto> Queryable => DbSet.OrderBy(e => e.Group).ThenBy(e => e.Order);
    public Task UpdateAsync(IList<TagDto> tags) =>
        this.ExecuteAsync(Logger, () =>
        {
            using var transaction = DbContext.Database.BeginTransaction();
            try
            {
                DbSet.RemoveAll();
                DbSet.AddRange(tags);
                DbContext.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        });
}
