using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface ISelectByIdPresentableUseCase<TOut, TGateway, TPresenter> : IUseCase<long, TOut?>
    where TGateway : ISelectByIdGateway<TOut>
    where TPresenter : ISelectByIdPresenter<TOut?>
{
}
