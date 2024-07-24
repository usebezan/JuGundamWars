using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Application;

internal class InsertServerInteractor<TInOut, TGateway, TSanitizer>(
    TGateway gateway,
    TSanitizer sanitizer,
    ILogger<InsertServerInteractor<TInOut, TGateway, TSanitizer>> logger) :
        InsertInteractorBase<TInOut>(gateway, presenter: null, sanitizer, validator: null, logger),
        IInsertServerUseCase<TInOut, TGateway, TSanitizer>
    where TInOut : class
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
{
}

internal class InsertServerInteractor<TInOut, TGateway, TSanitizer, TValidator>(
    TGateway gateway,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<InsertServerInteractor<TInOut, TGateway, TSanitizer, TValidator>> logger) :
        InsertInteractorBase<TInOut>(gateway, presenter: null, sanitizer, validator, logger),
        IInsertServerUseCase<TInOut, TGateway, TSanitizer, TValidator>
    where TInOut : class
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
}
