using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Application;

internal class SelectAllServerInteractor<TOut, TGateway>(
    TGateway gateway,
    ILogger<SelectAllServerInteractor<TOut, TGateway>> logger) :
        SelectAllInteractorBase<TOut>(gateway, presenter: null, logger),
        ISelectAllServerUseCase<TOut, TGateway>
    where TOut : class
    where TGateway : ISelectAllGateway<TOut>
{
}
