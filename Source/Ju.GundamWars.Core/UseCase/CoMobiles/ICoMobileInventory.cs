using Ju.GundamWars.Domain.CoMobiles;

namespace Ju.GundamWars.UseCase.CoMobiles;

public interface ICoMobileInventory : IInventory<CoMobileSubject>
{
    IObservable<string?> ItemPropertyChanged { get; }
}
