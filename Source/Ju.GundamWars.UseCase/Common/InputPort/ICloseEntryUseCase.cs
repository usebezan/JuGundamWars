namespace Ju.GundamWars.UseCase.Common.InputPort;

public interface ICloseEntryUseCase<TIn>
{
    Task HandleAsync((TIn, TIn) input);
}
