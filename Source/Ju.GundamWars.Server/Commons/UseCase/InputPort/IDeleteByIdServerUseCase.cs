using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;

namespace Ju.GundamWars.Server.Commons.UseCase.InputPort;

public interface IDeleteByIdServerUseCase<TOut, TGateway> : IDeleteByIdUseCase<TOut>
    where TOut : class
    where TGateway : IDeleteByIdGateway<TOut>
{
}
