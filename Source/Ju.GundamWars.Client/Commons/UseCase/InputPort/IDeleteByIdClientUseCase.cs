using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Commons.UseCase.InputPort;

public interface IDeleteByIdClientUseCase<TOut, TGateway, TPresenter> : IDeleteByIdUseCase<TOut>
    where TOut : class
    where TGateway : IDeleteByIdGateway<TOut>
    where TPresenter : IDeleteByIdPresenter<TOut>
{
}
