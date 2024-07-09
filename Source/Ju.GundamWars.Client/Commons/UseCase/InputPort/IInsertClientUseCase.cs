using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Commons.UseCase.InputPort;

public interface IInsertClientUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator> : IInsertUseCase<TInOut>
    where TInOut : class
    where TGateway : IInsertGateway<TInOut>
    where TPresenter : IInsertPresenter<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
}
