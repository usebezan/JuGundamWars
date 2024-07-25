namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface IInsertGateway<TInOut>
{
    Task<TInOut> InsertAsync(TInOut data);
}
