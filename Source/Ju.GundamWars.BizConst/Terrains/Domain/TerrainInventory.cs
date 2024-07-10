using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizConst.Terrains.Domain;

public class TerrainInventory : MasterObservableCollection<Terrain>
{
    public TerrainInventory()
    {
        AddRange<TerrainType>(e => e != TerrainType.Unknown, e => new(e));
    }
}
