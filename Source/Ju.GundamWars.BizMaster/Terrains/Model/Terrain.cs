using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Terrains.Model;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
