using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.Positions.Domain;

public class PositionInventory : MasterInventory<Position>
{
    public PositionInventory()
    {
        AddRange<PositionType>(e => e != PositionType.Unknown, e => new(e));
    }
}
