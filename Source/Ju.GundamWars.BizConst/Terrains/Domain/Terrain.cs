using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizConst.Terrains.Domain;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
