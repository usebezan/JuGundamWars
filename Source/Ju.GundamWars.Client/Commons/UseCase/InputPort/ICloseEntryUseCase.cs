namespace Ju.GundamWars.Client.Commons.UseCase.InputPort;

public interface ICloseEntryUseCase<TIn>
{
    Task HandleAsync((TIn, TIn) input);
}
