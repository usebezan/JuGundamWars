using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record Boost(BoostType Type) : TypeRecord2<BoostType>(Type, Type.ToValue(), Type.ToText(), string.Empty) { }
