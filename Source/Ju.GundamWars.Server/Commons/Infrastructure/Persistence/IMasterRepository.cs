using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Server.Commons.Infrastructure.Persistence;

public interface IMasterRepository<T>
    where T : class, IIdentify, IOrderable
{
    Task<List<T>> SelectAllAsync();
}
