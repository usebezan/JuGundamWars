using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;

namespace Ju.GundamWars.Client.Commons.UseCase.InputPort;

public interface IUpdateClientUseCase<TInOut, TGateway, TPresenter, TSanitizer, TValidator> : IUpdateUseCase<TInOut>
    where TInOut : class
    where TGateway : IUpdateGateway<TInOut>
    where TPresenter : IUpdatePresenter<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
}
