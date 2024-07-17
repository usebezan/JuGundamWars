using Ju.GundamWars.Commons.Application;
using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Server.Commons.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Server.Commons.Application;

internal class DeleteByIdServerInteractor<TOut, TGateway>(
    TGateway gateway,
    ILogger<DeleteByIdServerInteractor<TOut, TGateway>> logger) :
        DeleteByIdInteractorBase<TOut>(gateway, presenter: null, logger),
        IDeleteByIdServerUseCase<TOut, TGateway>
    where TOut : class
    where TGateway : IDeleteByIdGateway<TOut>
{
}
