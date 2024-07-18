using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;

namespace Ju.GundamWars.Server.Commons.UseCase.InputPort;

public interface IUpdateServerUseCase<TInOut, TGateway, TSanitizer> : IUpdateUseCase<TInOut>
    where TInOut : class
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
{
}

public interface IUpdateServerUseCase<TInOut, TGateway, TSanitizer, TValidator> : IUpdateUseCase<TInOut>
    where TInOut : class
    where TGateway : IUpdateGateway<TInOut>
    where TSanitizer : IUpdateSanitizer<TInOut>
    where TValidator : IUpdateValidator<TInOut>
{
}
