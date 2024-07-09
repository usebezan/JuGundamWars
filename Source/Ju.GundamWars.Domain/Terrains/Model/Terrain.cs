using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.Terrains.Model;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
