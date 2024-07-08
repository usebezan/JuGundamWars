using Ju.GundamWars.Domain.Supports;

namespace Ju.GundamWars.UseCase.Supports;

public interface ISupportInventory : IInventory<SupportSubject>
{
    IObservable<string?> ItemPropertyChanged { get; }
}
