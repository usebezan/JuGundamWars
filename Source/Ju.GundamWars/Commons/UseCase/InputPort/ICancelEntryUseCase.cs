using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.Commons.UseCase.InputPort;

public interface ICancelEntryUseCase<TIn>
{
    Task HandleAsync((EntryMode, TIn, TIn?) input);
}
