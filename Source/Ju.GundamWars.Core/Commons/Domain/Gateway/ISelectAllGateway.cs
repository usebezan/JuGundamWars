namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface ISelectAllGateway<TOut>
{
    Task<List<TOut>> SelectAllAsync();
}
