using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Server.Commons.Domain.Gateway;

public interface ITxnGateway<T>
    where T : class, IIdentify
{
    Task<List<T>> SelectAllAsync();
}
