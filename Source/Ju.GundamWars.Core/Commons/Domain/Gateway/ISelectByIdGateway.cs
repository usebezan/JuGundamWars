namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface ISelectByIdGateway<TOut>
{
    Task<TOut?> SelectByIdAsync(long id);
}
