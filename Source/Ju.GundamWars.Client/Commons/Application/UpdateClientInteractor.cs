using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Commons.Application;

internal class UpdateClientInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>(
    TGateway gateway,
    TPresenter presenter,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<UpdateClientInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>> logger) :
        UpdateInteractorBase<TInOut>(gateway, presenter, sanitizer, validator, logger),
        IUpdateClientUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator>
    where TInOut : class
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
}
