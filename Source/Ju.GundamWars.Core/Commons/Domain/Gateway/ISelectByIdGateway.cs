namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface ISelectByIdGateway<T>
    where T : class
{
    Task<T?> SelectByIdAsync(long id);
}
