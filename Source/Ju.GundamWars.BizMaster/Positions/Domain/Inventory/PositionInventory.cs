using Ju.GundamWars.BizMaster.Positions.Domain.Model;
using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Positions.Domain.Inventory;

public class PositionInventory : MasterObservableCollection<Position>
{
    public PositionInventory()
    {
        AddRange<PositionType>(e => e != PositionType.Unknown, e => new(e));
    }
}
