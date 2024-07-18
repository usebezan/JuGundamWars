using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.BizMaster.Versionings.Domain;

public interface IVersioningGateway<T> : ISelectByIdGateway<T>
    where T : class, IVersioning
{
}
