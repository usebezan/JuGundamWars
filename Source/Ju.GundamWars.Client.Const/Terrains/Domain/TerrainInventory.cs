using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Terrains.Domain;

namespace Ju.GundamWars.Client.Terrains.Domain;

public class TerrainInventory : MasterInventory<Terrain>
{
    public TerrainInventory()
    {
        AddRange<TerrainType>(e => e != TerrainType.Unknown, e => new(e));
    }
}
