using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.Server.Commons.Domain.Gateway;

public interface ITxnRepository<T> : IGw, ISelectAllGateway<T>, IInsertGateway<T>, IUpdateGateway<T>, IDeleteGateway<long, T>
    where T : IIdentifiable
{
}
