using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
