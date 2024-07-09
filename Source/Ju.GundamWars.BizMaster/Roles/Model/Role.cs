using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Roles.Model;

public record Role(RoleType Type) : TypeRecord<RoleType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
