using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Application;

internal class UpdateServerInteractor<TInOut, TGateway, TSanitizer>(
    TGateway gateway,
    TSanitizer sanitizer,
    ILogger<UpdateServerInteractor<TInOut, TGateway, TSanitizer>> logger) :
        UpdateInteractorBase<TInOut>(gateway, presenter: null, sanitizer, validator: null, logger),
        IUpdateServerUseCase<TInOut, TGateway, TSanitizer>
    where TInOut : class
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
{
}

internal class UpdateServerInteractor<TInOut, TGateway, TSanitizer, TValidator>(
    TGateway gateway,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<UpdateServerInteractor<TInOut, TGateway, TSanitizer, TValidator>> logger) :
        UpdateInteractorBase<TInOut>(gateway, presenter: null, sanitizer, validator, logger),
        IUpdateServerUseCase<TInOut, TGateway, TSanitizer, TValidator>
    where TInOut : class
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
}
