using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

// NOTE: ホストに一括登録できるようにするためジェネリックで受け取る

public interface IInsertUseCase<TInOut, TGateway> : IUseCase<TInOut, TInOut>
    where TGateway : IInsertGateway<TInOut>
{
}

public interface IInsertUseCase<TInOut, TGateway, TSanitizer> : IUseCase<TInOut, TInOut>
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
{
}

public interface IInsertUseCase<TInOut, TGateway, TSanitizer, TValidator> : IUseCase<TInOut, TInOut>
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
}
