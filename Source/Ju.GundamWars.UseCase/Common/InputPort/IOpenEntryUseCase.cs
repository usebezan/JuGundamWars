namespace Ju.GundamWars.UseCase.Common.InputPort;

public interface IOpenEntryUseCase<TIn>
{
    Task HandleAsync(TIn input);
}
