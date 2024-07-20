using Ju.GundamWars.Application;
using Ju.GundamWars.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

namespace Ju.GundamWars.Persistence2;

public abstract class RepositoryBase<TEntity>(IDbContextFactory<GwDbContext> factory, ILogger logger)
    : ReadOnlyRepositoryBase<TEntity, GwDbContext>(factory, logger), IRepository<TEntity>
    where TEntity : class, IIdentify
{

    protected Task<(TEntity self, List<Mobile>? exes)> SaveChangesAsync(Func<GwDbContext, (TEntity self, List<int>? exMobileIds)> executor, [CallerMemberName] string? callerMemberName = null) =>
        Execute<Task<(TEntity, List<Mobile>?)>>(async dbContext =>
        {
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                var (self, exMobileIds) = executor(dbContext);
                dbContext.ChangeTracker.DetectChanges();
                dbContext.SaveChanges();
                await transaction.CommitAsync();
                return (self, exMobileIds == null ? null : dbContext.IncludedMobiles.Where(e => exMobileIds.Contains(e.Id)).ToList());
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }, callerMemberName);

    public abstract Task<(TEntity self, List<Mobile>? exes)> InsertAsync(TEntity entity);
    public abstract Task<(TEntity self, List<Mobile>? exes)> UpdateAsync(TEntity entity);
    public abstract Task<(TEntity self, List<Mobile>? exes)> DeleteByIdAsync(int id);

}

public abstract class RepositoryBase2<TEntity>(IDbContextFactory<GwDbContext> factory, ILogger logger)
    : RepositoryBase<TEntity>(factory, logger)
    where TEntity : class, IIdentify
{

    public override Task<(TEntity self, List<Mobile>? exes)> InsertAsync(TEntity entity) =>
        SaveChangesAsync(dbContext =>
        {
            SetZeroToId(entity);
            return (dbContext.Set<TEntity>().Add(entity).Entity, null);
        });

    public override Task<(TEntity self, List<Mobile>? exes)> UpdateAsync(TEntity entity) =>
        SaveChangesAsync(dbContext =>
        {
            DeleteRelations(dbContext, entity.Id);
            SetZeroToId(entity);
            return (dbContext.Set<TEntity>().Update(entity).Entity, null);
        });

    public override Task<(TEntity self, List<Mobile>? exes)> DeleteByIdAsync(int id) =>
        SaveChangesAsync(dbContext =>
        {
            var exMobileIds = DeleteExMobileRelations(dbContext, id);
            DeleteRelations(dbContext, id);
            return (dbContext.Set<TEntity>().Remove(e => e.Id == id).Entity, exMobileIds);
        });

    // 元々付いていた機体の関係を削除する
    protected abstract List<int> DeleteExMobileRelations(GwDbContext dbContext, int id);

    // 子を明示的に削除
    protected abstract void DeleteRelations(GwDbContext dbContext, int id);

    // DbUpdateConcurrencyException
    protected abstract void SetZeroToId(TEntity entity);

}
