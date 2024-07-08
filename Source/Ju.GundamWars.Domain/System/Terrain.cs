using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record Terrain(TerrainType Type) : TypeRecord<TerrainType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
