namespace Ju.GundamWars.Domain.Common.Gateway;

public interface IUpdateGateway<T>
    where T : class
{
    Task<T> UpdateAsync(T data);
}
