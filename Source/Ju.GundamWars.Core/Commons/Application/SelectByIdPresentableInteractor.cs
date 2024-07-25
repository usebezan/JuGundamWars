using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class SelectByIdPresentableInteractor<TOut, TGateway, TPresenter>(TGateway gateway, TPresenter presenter, ILogger<SelectByIdPresentableInteractor<TOut, TGateway, TPresenter>> logger)
    : PresentableInteractorBase<long, TOut?, TPresenter>(presenter, sanitizer: null, validator: null, logger), ISelectByIdPresentableUseCase<TOut, TGateway, TPresenter>
    where TGateway : ISelectByIdGateway<TOut>
    where TPresenter : ISelectByIdPresenter<TOut?>
{
    public Task<TOut?> HandleAsync(long input) =>
        HandleAsync(input, gateway.SelectByIdAsync);
}
