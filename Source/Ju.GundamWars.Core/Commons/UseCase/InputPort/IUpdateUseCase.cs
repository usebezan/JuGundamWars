using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface IUpdateUseCase<TInOut, TGateway> : IUseCase<TInOut, TInOut>
    where TGateway : IUpdateGateway<TInOut>
{
}

public interface IUpdateUseCase<TInOut, TGateway, TSanitizer> : IUseCase<TInOut, TInOut>
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
{
}

public interface IUpdateUseCase<TInOut, TGateway, TSanitizer, TValidator> : IUseCase<TInOut, TInOut>
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
}
