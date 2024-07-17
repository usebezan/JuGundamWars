using Ju.GundamWars.Commons.Domain.Gateway;
using Ju.GundamWars.Commons.Domain.Service.Sanitization;
using Ju.GundamWars.Commons.Domain.Service.Validation;
using Ju.GundamWars.Commons.UseCase.InputPort;

namespace Ju.GundamWars.Server.Commons.UseCase.InputPort;

public interface IInsertServerUseCase<TInOut, TGateway, TSanitizer, TValidator> : IInsertUseCase<TInOut>
    where TInOut : class
    where TGateway : IInsertGateway<TInOut>
    where TSanitizer : IInsertSanitizer<TInOut>
    where TValidator : IInsertValidator<TInOut>
{
}
