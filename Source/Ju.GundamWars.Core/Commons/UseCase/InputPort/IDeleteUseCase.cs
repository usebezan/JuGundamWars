using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface IDeleteUseCase<TIn, TOut, TGateway> : IUseCase<TIn, TOut>
    where TGateway : IDeleteGateway<TIn, TOut>
{
}
