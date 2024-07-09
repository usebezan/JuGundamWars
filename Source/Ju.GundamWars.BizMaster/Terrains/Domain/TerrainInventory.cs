using Ju.GundamWars.Collections;

namespace Ju.GundamWars.BizMaster.Terrains.Domain;

public class TerrainInventory : EnumObservableCollection<Terrain>
{
    public TerrainInventory()
    {
        AddRange<TerrainType>(e => e != TerrainType.Unknown, e => new(e));
    }
}
