using Ju.GundamWars.Domain.Mobiles.Entities;

namespace Ju.GundamWars.Application;

public interface IRepository<TEntity> : IReadOnlyRepository<TEntity>
{
    Task<(TEntity self, List<Mobile>? exes)> InsertAsync(TEntity entity);
    Task<(TEntity self, List<Mobile>? exes)> UpdateAsync(TEntity entity);
    Task<(TEntity self, List<Mobile>? exes)> DeleteByIdAsync(int id);
}
