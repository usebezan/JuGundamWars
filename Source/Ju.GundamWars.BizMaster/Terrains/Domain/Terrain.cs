using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Terrains.Domain;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
