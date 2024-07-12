using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public interface ITxnRepository<T>
    where T : class, IIdentify
{
    Task<List<T>> SelectAllAsync();
}
