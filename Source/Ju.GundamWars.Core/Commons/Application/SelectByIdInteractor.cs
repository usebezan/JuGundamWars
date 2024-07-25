using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class SelectByIdInteractor<TOut, TGateway>(TGateway gateway, ILogger<SelectByIdInteractor<TOut, TGateway>> logger)
    : InteractorBase<long, TOut?>(sanitizer: null, validator: null, logger), ISelectByIdUseCase<TOut, TGateway>
    where TGateway : ISelectByIdGateway<TOut>
{
    public Task<TOut?> HandleAsync(long input) =>
        HandleAsync(input, gateway.SelectByIdAsync);
}
