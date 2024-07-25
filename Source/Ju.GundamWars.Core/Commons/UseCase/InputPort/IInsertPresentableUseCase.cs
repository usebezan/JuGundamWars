using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface IInsertPresentableUseCase<TInOut, TGateway, TPresenter> : IUseCase<TInOut, TInOut>
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
{
}

public interface IInsertPresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer> : IUseCase<TInOut, TInOut>
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
{
}

public interface IInsertPresentableUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator> : IUseCase<TInOut, TInOut>
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
}
