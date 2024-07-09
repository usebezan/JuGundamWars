namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface IUpdateGateway<T>
    where T : class
{
    Task<T> UpdateAsync(T data);
}
