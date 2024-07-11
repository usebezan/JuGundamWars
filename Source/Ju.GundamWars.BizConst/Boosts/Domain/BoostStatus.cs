using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizConst.Boosts.Domain;

public record BoostStatus(BoostStatusType Type) : TypeRecord<BoostStatusType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
