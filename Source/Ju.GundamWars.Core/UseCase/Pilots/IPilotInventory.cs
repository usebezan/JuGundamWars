using Ju.GundamWars.Domain.Pilots;

namespace Ju.GundamWars.UseCase.Pilots;

public interface IPilotInventory : IInventory<PilotSubject>
{
    IObservable<string?> ItemPropertyChanged { get; }
}
