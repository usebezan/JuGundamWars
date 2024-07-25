using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class UpdateInteractor<TInOut, TGateway>(
    TGateway gateway,
    ILogger<UpdateInteractor<TInOut, TGateway>> logger)
    : InteractorBase<TInOut, TInOut>(sanitizer: null, validator: null, logger), IUpdateUseCase<TInOut, TGateway>
    where TGateway : IUpdateGateway<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.UpdateAsync);
}

public class UpdateInteractor<TInOut, TGateway, TSanitizer>(
    TGateway gateway,
    TSanitizer sanitizer,
    ILogger<UpdateInteractor<TInOut, TGateway, TSanitizer>> logger)
    : InteractorBase<TInOut, TInOut>(sanitizer, validator: null, logger), IUpdateUseCase<TInOut, TGateway, TSanitizer>
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.UpdateAsync);
}

public class UpdateInteractor<TInOut, TGateway, TSanitizer, TValidator>(
    TGateway gateway,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<UpdateInteractor<TInOut, TGateway, TSanitizer, TValidator>> logger)
    : InteractorBase<TInOut, TInOut>(sanitizer, validator, logger), IUpdateUseCase<TInOut, TGateway, TSanitizer, TValidator>
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.UpdateAsync);
}
