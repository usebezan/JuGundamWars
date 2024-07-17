namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface ISelectAllGateway<T>
    where T : class
{
    Task<List<T>> SelectAllAsync();
}
