using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public abstract class InsertInteractorBase<TInOut>(
    IInsertGateway<TInOut> gateway,
    IInsertPresenter<TInOut>? presenter,
    IInsertSanitizer<TInOut>? sanitizer,
    IInsertValidator<TInOut>? validator,
    ILogger logger) :
        InteractorBase<TInOut, TInOut>(presenter, sanitizer, validator, logger),
        IInsertUseCase<TInOut>
    where TInOut : class
{
    protected IInsertGateway<TInOut> Gateway { get; } = gateway;
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, Gateway.InsertAsync);
}
