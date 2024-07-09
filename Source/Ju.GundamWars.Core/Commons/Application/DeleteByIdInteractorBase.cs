using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public abstract class DeleteByIdInteractorBase<TOut>(
    IDeleteByIdGateway<TOut> gateway,
    IDeleteByIdPresenter<TOut>? presenter,
    ILogger logger) :
        InteractorBase<long, TOut>(presenter, sanitizer: null, validator: null, logger),
        IDeleteByIdUseCase<TOut>
    where TOut : class
{
    protected IDeleteByIdGateway<TOut> Gateway { get; } = gateway;
    public Task<TOut> HandleAsync(long input) =>
        HandleAsync(input, Gateway.DeleteByIdAsync);
}
