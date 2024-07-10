using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Roles.Domain.Model;

public record Role(RoleType Type) : TypeRecord<RoleType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public bool ForMobileSuit { get; } = Type.ForMobileSuit();
    public bool ForMobileArmor { get; } = Type.ForMobileArmor();
}
