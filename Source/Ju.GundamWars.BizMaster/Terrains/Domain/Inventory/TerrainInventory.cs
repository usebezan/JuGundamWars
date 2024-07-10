using Ju.GundamWars.BizMaster.Terrains.Domain.Model;
using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Terrains.Domain.Inventory;

public class TerrainInventory : MasterObservableCollection<Terrain>
{
    public TerrainInventory()
    {
        AddRange<TerrainType>(e => e != TerrainType.Unknown, e => new(e));
    }
}
