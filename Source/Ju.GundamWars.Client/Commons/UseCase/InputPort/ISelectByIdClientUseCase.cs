using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Commons.UseCase.InputPort;

public interface ISelectByIdClientUseCase<TOut, TGateway, TPresenter> : ISelectByIdUseCase<TOut?>
    where TOut : class
    where TGateway : ISelectByIdGateway<TOut>
    where TPresenter : ISelectByIdPresenter<TOut>
{
}
