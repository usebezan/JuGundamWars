using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface IDeletePresentableUseCase<TIn, TOut, TGateway, TPresenter> : IUseCase<TIn, TOut>
    where TGateway : IDeleteGateway<TIn, TOut>
    where TPresenter : IDeletePresenter<TOut>
{
}
