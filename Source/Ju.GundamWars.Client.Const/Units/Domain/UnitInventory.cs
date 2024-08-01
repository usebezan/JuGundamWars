using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Client.Units.Domain;

public class UnitInventory : MasterInventory<Unit>
{
    public UnitInventory()
    {
        AddRange<UnitType>(e => e != UnitType.Unknown, e => new(e));
    }
}
