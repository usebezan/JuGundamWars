using Ju.GundamWars.BizTxn.Tags.Domain.Entity;
using Ju.GundamWars.BizTxn.Tags.Domain.Gateway;
using Ju.GundamWars.Server.Commons.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Tags.Infrastructure.Persistence;

public class TagRepository(IDbContextFactory<GwTxnDbContext> factory, ILogger<TagRepository> logger) : IGw, ITagGateway<TagEntity>
{

    private readonly GwTxnDbContext dbContext = factory.CreateDbContext();


    public Task<List<TagEntity>> SelectAllAsync() =>
        this.ExecuteAsync(logger, () => dbContext.Set<TagEntity>().OrderBy(e => e.Group).ThenBy(e => e.Order).ToList());

    public Task UpdateAllAsync(IList<TagEntity> tags) =>
        this.ExecuteAsync(logger, () =>
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                var dbSet = dbContext.Set<TagEntity>();
                dbSet.RemoveAll();
                dbSet.AddRange(tags);
                dbContext.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        });

}
