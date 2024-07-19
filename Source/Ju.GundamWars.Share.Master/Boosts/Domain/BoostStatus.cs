using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Share.Boosts.Domain;

// TODO: 必要？
public record BoostStatus(BoostStatusType Type) : TypeRecord<BoostStatusType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
