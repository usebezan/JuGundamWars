using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Commons.Application;

internal class SelectByIdClientInteractor<TOut, TGateway, TPresenter>(
    TGateway gateway,
    TPresenter presenter,
    ILogger<SelectByIdClientInteractor<TOut, TGateway, TPresenter>> logger) :
        SelectByIdInteractorBase<TOut>(gateway, presenter, logger),
        ISelectByIdClientUseCase<TOut, TGateway, TPresenter>
    where TOut : class
    where TGateway : ISelectByIdGateway<TOut>
    where TPresenter : ISelectByIdPresenter<TOut>
{
}
