using Ju.GundamWars.Client.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Server.Tags.Domain.Service.Validation;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Commons.Application;

internal class InsertClientInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>(
    TGateway gateway,
    TPresenter presenter,
    TSanitizer sanitizer,
    TValidator validator,
    ILogger<InsertClientInteractor<TInOut, TGateway, TPresenter, TSanitizer, TValidator>> logger) :
        InsertInteractorBase<TInOut>(gateway, presenter, sanitizer, validator, logger),
        IInsertClientUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator>
    where TInOut : class
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
}
