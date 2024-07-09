using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Boosts.Model;

public record Boost(BoostType Type) : TypeRecord<BoostType, int>(Type, Type.ToValue(), Type.ToText())
{
}
