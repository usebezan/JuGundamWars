using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public abstract class UpdateInteractorBase<TInOut>(
    IUpdateGateway<TInOut> gateway,
    IUpdatePresenter<TInOut>? presenter,
    IUpdateSanitizer<TInOut>? sanitizer,
    IUpdateValidator<TInOut>? validator,
    ILogger logger) :
        InteractorBase<TInOut, TInOut>(presenter, sanitizer, validator, logger),
        IUpdateUseCase<TInOut>
    where TInOut : class
{
    protected IUpdateGateway<TInOut> Gateway { get; } = gateway;
    public Task<TInOut> HandleAsync(TInOut input) =>
        HandleAsync(input, Gateway.UpdateAsync);
}
