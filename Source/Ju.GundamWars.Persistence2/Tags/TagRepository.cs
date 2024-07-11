using Ju.GundamWars.Application.Tags.Repositories;
using Ju.GundamWars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Persistence2.Tags;

public class TagRepository(IDbContextFactory<GwDbContext> factory, ILogger<TagRepository> logger)
    : ReadOnlyRepositoryBase<Tag, GwDbContext>(factory, logger), ITagRepository
{

    public override List<Tag> SelectAll() =>
        Execute(dbContext => dbContext.Set<Tag>().OrderBy(e => e.Order).ToList());

    public Task UpdateAsync(IList<Tag> tags) =>
        Execute(async dbContext =>
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                dbContext.Set<Tag>().RemoveRange(_ => true);
                dbContext.Set<Tag>().AddRange(tags);
                dbContext.ChangeTracker.DetectChanges();
                dbContext.SaveChanges();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
            return true;
        });

}
