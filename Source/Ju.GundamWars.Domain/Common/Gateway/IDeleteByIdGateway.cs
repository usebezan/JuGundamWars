namespace Ju.GundamWars.Domain.Common.Gateway;

public interface IDeleteByIdGateway<T>
    where T : class
{
    Task<T> DeleteByIdAsync(long id);
}
