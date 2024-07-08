using Ju.GundamWars.Domain.Mobiles;

namespace Ju.GundamWars.UseCase.Mobiles;

public interface IMobileInventory : IInventory<MobileSubject>
{
    IObservable<string?> ItemPropertyChanged { get; }
}
