namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface IInsertGateway<T>
    where T : class
{
    Task<T> InsertAsync(T data);
}
