using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;

namespace Ju.GundamWars.Server.Commons.UseCase.InputPort;

public interface ISelectByIdServerUseCase<TOut, TGateway> : ISelectByIdUseCase<TOut?>
    where TOut : class
    where TGateway : ISelectByIdGateway<TOut>
{
}
