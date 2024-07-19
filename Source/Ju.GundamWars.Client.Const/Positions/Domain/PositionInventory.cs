using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Positions.Domain;

namespace Ju.GundamWars.Client.Positions.Domain;

public class PositionInventory : MasterInventory<Position>
{
    public PositionInventory()
    {
        AddRange<PositionType>(e => e != PositionType.Unknown, e => new(e));
    }
}
