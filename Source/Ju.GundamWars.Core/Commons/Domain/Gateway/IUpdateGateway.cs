namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface IUpdateGateway<TInOut>
{
    Task<TInOut> UpdateAsync(TInOut data);
}
