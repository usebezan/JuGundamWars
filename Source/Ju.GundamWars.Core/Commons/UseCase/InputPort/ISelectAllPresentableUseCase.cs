using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface ISelectAllPresentableUseCase<TOut, TGateway, TPresenter> : IUseCase<List<TOut>>
    where TGateway : ISelectAllGateway<TOut>
    where TPresenter : ISelectAllPresenter<TOut>
{
}
