using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class SelectAllPresentableInteractor<TOut, TGateway, TPresenter>(TGateway gateway, TPresenter presenter, ILogger<SelectAllInteractor<TOut, TGateway>> logger)
    : PresentableInteractorBase<long, List<TOut>, TPresenter>(presenter, sanitizer: null, validator: null, logger), ISelectAllPresentableUseCase<TOut, TGateway, TPresenter>
    where TGateway : ISelectAllGateway<TOut>
    where TPresenter : ISelectAllPresenter<TOut>
{
    public Task<List<TOut>> HandleAsync() =>
        HandleAsync(0, _ => gateway.SelectAllAsync());
}
