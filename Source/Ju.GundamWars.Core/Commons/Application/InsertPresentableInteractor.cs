using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class InsertPresentableInteractor<TInOut, TGateway, TPresenter>(
    TGateway gateway,
    TPresenter presenter,
    ILogger<InsertPresentableInteractor<TInOut, TGateway, TPresenter>> logger)
    : PresentableInteractorBase<TInOut, TInOut, TPresenter>(presenter, sanitizer: null, validator: null, logger), IInsertPresentableUseCase<TInOut, TGateway, TPresenter>
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.InsertAsync);
}

public class InsertPresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer>(
    TGateway gateway,
    TPresenter presenter,
    TSanitizer sanitizer,
    ILogger<InsertPresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer>> logger)
    : PresentableInteractorBase<TInOut, TInOut, TPresenter>(presenter, sanitizer, validator: null, logger), IInsertPresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer>
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.InsertAsync);
}

public class InsertPresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>(
    TGateway gateway,
    TPresenter presenter,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<InsertPresentableInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>> logger)
    : PresentableInteractorBase<TInOut, TInOut, TPresenter>(presenter, sanitizer, validator, logger), IInsertPresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator>
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.InsertAsync);
}
