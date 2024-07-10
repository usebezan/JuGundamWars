using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizConst.Positions.Domain;

public class PositionInventory : MasterObservableCollection<Position>
{
    public PositionInventory()
    {
        AddRange<PositionType>(e => e != PositionType.Unknown, e => new(e));
    }
}
