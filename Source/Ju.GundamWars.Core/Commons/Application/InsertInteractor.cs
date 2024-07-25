using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class InsertInteractor<TInOut, TGateway>(
    TGateway gateway,
    ILogger<InsertInteractor<TInOut, TGateway>> logger)
    : InteractorBase<TInOut, TInOut>(sanitizer: null, validator: null, logger), IInsertUseCase<TInOut, TGateway>
    where TGateway : IInsertGateway<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.InsertAsync);
}

public class InsertInteractor<TInOut, TGateway, TSanitizer>(
    TGateway gateway,
    TSanitizer sanitizer,
    ILogger<InsertInteractor<TInOut, TGateway, TSanitizer>> logger)
    : InteractorBase<TInOut, TInOut>(sanitizer, validator: null, logger), IInsertUseCase<TInOut, TGateway, TSanitizer>
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.InsertAsync);
}

public class InsertInteractor<TInOut, TGateway, TSanitizer, TValidator>(
    TGateway gateway,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<InsertInteractor<TInOut, TGateway, TSanitizer, TValidator>> logger)
    : InteractorBase<TInOut, TInOut>(sanitizer, validator, logger), IInsertUseCase<TInOut, TGateway, TSanitizer, TValidator>
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, gateway.InsertAsync);
}
