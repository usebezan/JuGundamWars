using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class UpdatePresentableInteractor<TInOut, TGateway, TPresenter>(
    TGateway gateway,
    TPresenter presenter,
    ILogger<UpdatePresentableInteractor<TInOut, TGateway, TPresenter>> logger)
    : PresentableInteractorBase<TInOut, TInOut, TPresenter>(presenter, sanitizer: null, validator: null, logger), IUpdatePresentableUseCase<TInOut, TGateway, TPresenter>
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.UpdateAsync);
}

public class UpdatePresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer>(
    TGateway gateway,
    TPresenter presenter,
    TSanitizer sanitizer,
    ILogger<UpdatePresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer>> logger)
    : PresentableInteractorBase<TInOut, TInOut, TPresenter>(presenter, sanitizer, validator: null, logger), IUpdatePresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer>
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.UpdateAsync);
}

public class UpdatePresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>(
    TGateway gateway,
    TPresenter presenter,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<UpdatePresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>> logger)
    : PresentableInteractorBase<TInOut, TInOut, TPresenter>(presenter, sanitizer, validator, logger), IUpdatePresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator>
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.UpdateAsync);
}
