using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;

namespace Ju.GundamWars.Server.Commons.UseCase.InputPort;

public interface ISelectAllServerUseCase<TOut, TGateway> : ISelectAllUseCase<TOut>
    where TOut : class
    where TGateway : ISelectAllGateway<TOut>
{
}
