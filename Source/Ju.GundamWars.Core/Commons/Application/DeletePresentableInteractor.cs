using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class DeletePresentableInteractor<TIn, TOut, TGateway, TPresenter>(TGateway gateway, TPresenter presenter, ILogger<DeletePresentableInteractor<TIn, TOut, TGateway, TPresenter>> logger)
    : PresentableInteractorBase<TIn, TOut, TPresenter>(presenter, sanitizer: null, validator: null, logger), IDeletePresentableUseCase<TIn, TOut, TGateway, TPresenter>
    where TGateway : IDeleteGateway<TIn, TOut>
    where TPresenter : IDeletePresenter<TOut>
{
    public Task<TOut> HandleAsync(TIn input) =>
        HandleAsync(input, gateway.DeleteAsync);
}
