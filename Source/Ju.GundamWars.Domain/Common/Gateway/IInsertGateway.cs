namespace Ju.GundamWars.Domain.Common.Gateway;

public interface IInsertGateway<T>
    where T : class
{
    Task<T> InsertAsync(T data);
}
