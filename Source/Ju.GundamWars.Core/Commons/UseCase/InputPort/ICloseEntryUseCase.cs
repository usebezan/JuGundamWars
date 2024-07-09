namespace Ju.GundamWars.Commons.UseCase.InputPort;

public interface ICloseEntryUseCase<TIn>
{
    Task HandleAsync((TIn, TIn) input);
}
