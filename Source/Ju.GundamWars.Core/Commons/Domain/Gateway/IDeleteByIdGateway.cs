namespace Ju.GundamWars.Commons.Domain.Gateway;

public interface IDeleteByIdGateway<T>
    where T : class
{
    Task<T> DeleteByIdAsync(long id);
}
