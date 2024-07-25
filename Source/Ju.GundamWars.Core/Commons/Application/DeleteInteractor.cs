using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class DeleteInteractor<TIn, TOut, TGateway>(TGateway gateway, ILogger<DeleteInteractor<TIn, TOut, TGateway>> logger)
    : InteractorBase<TIn, TOut>(sanitizer: null, validator: null, logger), IDeleteUseCase<TIn, TOut, TGateway>
    where TGateway : IDeleteGateway<TIn, TOut>
{
    public Task<TOut> HandleAsync(TIn input) =>
        HandleAsync(input, gateway.DeleteAsync);
}
