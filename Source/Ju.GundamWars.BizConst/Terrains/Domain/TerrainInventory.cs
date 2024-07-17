using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizConst.Terrains.Domain;

public class TerrainInventory : MasterInventory<Terrain>
{
    public TerrainInventory()
    {
        AddRange<TerrainType>(e => e != TerrainType.Unknown, e => new(e));
    }
}
