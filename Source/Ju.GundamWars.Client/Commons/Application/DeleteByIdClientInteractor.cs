using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Commons.Application;

internal class DeleteByIdClientInteractor<TOut, TGateway, TPresenter>(
    TGateway gateway,
    TPresenter presenter,
    ILogger<DeleteByIdClientInteractor<TOut, TGateway, TPresenter>> logger) :
        DeleteByIdInteractorBase<TOut>(gateway, presenter, logger),
        IDeleteByIdClientUseCase<TOut, TGateway, TPresenter>
    where TOut : class
    where TGateway : IDeleteByIdGateway<TOut>
    where TPresenter : IDeleteByIdPresenter<TOut>
{
}
