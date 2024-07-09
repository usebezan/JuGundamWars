using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Positions.Domain;

public class PositionInventory : EnumObservableCollection<Position>
{
    public PositionInventory()
    {
        AddRange<PositionType>(e => e != PositionType.Unknown, e => new(e));
    }
}
