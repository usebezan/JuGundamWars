using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.Boosts.Model;

public record Boost(BoostType Type) : TypeRecord<BoostType, int>(Type, Type.ToValue(), Type.ToText())
{
}
