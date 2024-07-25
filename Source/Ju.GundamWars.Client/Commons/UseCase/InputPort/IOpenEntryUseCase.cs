namespace Ju.GundamWars.Client.Commons.UseCase.InputPort;

public interface IOpenEntryUseCase<TIn>
{
    Task HandleAsync(TIn input);
}
