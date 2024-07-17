using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.Server.Commons.Domain.Gateway;

public interface IMasterRepository<T> : ISelectAllGateway<T>
    where T : class, IIdentify, IOrderable
{
}
