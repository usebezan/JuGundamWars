using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Share.Terrains.Domain;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
