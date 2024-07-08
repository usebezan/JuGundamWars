namespace Ju.GundamWars.Application;

public interface IReadOnlyRepository<TEntity>
{
    TEntity? Find(params object?[]? keyValues);
    TEntity? SelectById(int id);
    List<TEntity> SelectAll();
}
