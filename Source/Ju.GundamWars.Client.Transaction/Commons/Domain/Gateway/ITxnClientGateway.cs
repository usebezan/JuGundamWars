using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.Client.Commons.Domain.Gateway;

public interface ITxnClientGateway<T> : IGw, IInsertGateway<T>, IUpdateGateway<T>, IDeleteGateway<T, T>
    where T : IIdentifiable
{
}
