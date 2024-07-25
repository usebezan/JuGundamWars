namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface IDeleteGateway<TIn, TOut>
{
    Task<TOut> DeleteAsync(TIn data);
}
