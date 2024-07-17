using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Application;

internal class SelectByIdServerInteractor<TOut, TGateway>(
    TGateway gateway,
    ILogger<SelectByIdServerInteractor<TOut, TGateway>> logger) :
        SelectByIdInteractorBase<TOut>(gateway, presenter: null, logger),
        ISelectByIdServerUseCase<TOut, TGateway>
    where TOut : class
    where TGateway : ISelectByIdGateway<TOut>
{
}
