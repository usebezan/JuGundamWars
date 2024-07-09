using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster._.Boosts.Domain;

public record Boost(BoostType Type) : TypeRecord<BoostType, int>(Type, Type.ToValue(), Type.ToText())
{
}
