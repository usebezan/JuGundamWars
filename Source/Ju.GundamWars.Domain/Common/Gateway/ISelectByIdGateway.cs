namespace Ju.GundamWars.Domain.Common.Gateway;

public interface ISelectByIdGateway<T>
    where T : class
{
    Task<T?> SelectByIdAsync(long id);
}
