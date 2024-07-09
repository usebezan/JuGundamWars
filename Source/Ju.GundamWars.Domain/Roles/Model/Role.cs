using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.Roles.Model;

public record Role(RoleType Type) : TypeRecord<RoleType, byte>(Type, Type.ToValue(), Type.ToText())
{
}
