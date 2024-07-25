using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Commons.Application;

public class SelectAllInteractor<TOut, TGateway>(TGateway gateway, ILogger<SelectAllInteractor<TOut, TGateway>> logger)
    : InteractorBase<long, List<TOut>>(sanitizer: null, validator: null, logger), ISelectAllUseCase<TOut, TGateway>
    where TGateway : ISelectAllGateway<TOut>
{
    public Task<List<TOut>> HandleAsync() =>
        HandleAsync(0, _ => gateway.SelectAllAsync());
}
