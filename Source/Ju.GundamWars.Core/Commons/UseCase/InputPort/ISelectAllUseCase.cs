using Ju.GundamWars.Commons.Domain.Gateway;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface ISelectAllUseCase<TOut, TGateway> : IUseCase<List<TOut>>
    where TGateway : ISelectAllGateway<TOut>
{
}
