namespace Ju.GundamWars.Commons.UseCase.InputPort;

public interface ICancelEntryUseCase<TIn>
{
    Task HandleAsync((TIn @new, TIn? org) input);
}
