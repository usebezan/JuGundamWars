using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface IUpdatePresentableUseCase<TInOut, TGateway, TPresenter> : IUseCase<TInOut, TInOut>
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
{
}

public interface IUpdatePresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer> : IUseCase<TInOut, TInOut>
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
{
}

public interface IUpdatePresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator> : IUseCase<TInOut, TInOut>
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
}
