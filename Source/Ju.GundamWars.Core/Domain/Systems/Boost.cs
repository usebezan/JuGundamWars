using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record Boost(BoostType Type) : TypeRecord2<BoostType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
