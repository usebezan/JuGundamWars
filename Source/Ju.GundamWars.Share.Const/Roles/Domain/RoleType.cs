namespace Ju.GundamWars.Share.Roles.Domain;

public enum RoleType : byte
{
    Defensive = 1,
    Offensive,
    Support,
    Recovery,
    Disruptive,
    AllRounder,

    Defender = 11,
    Assault,
    Assistance,
    Supply,
    Disruption,
    Combined,

    Unknown = byte.MaxValue,
}

public static class RoleTypeExtension
{

    public static RoleType ToRoleType(this byte self)
    {
        try { return (RoleType)self; } catch { return RoleType.Unknown; }
    }

    public static byte ToValue(this RoleType self) =>
        (byte)self;

    public static string ToText(this RoleType self) =>
        self switch
        {
            RoleType.Defensive => "防衛型",
            RoleType.Offensive => "攻撃型",
            RoleType.Support => "支援型",
            RoleType.Recovery => "回復型",
            RoleType.Disruptive => "妨害型",
            RoleType.AllRounder => "万能型",

            RoleType.Defender => "守備型",
            RoleType.Assault => "強襲型",
            RoleType.Assistance => "援護型",
            RoleType.Supply => "補給型",
            RoleType.Disruption => "干渉型",
            RoleType.Combined => "統合型",

            _ => GwText.Unknown,
        };

    public static bool ForMobileSuit(this RoleType self) =>
        self switch
        {
            RoleType.Defensive => true,
            RoleType.Offensive => true,
            RoleType.Support => true,
            RoleType.Recovery => true,
            RoleType.Disruptive => true,
            RoleType.AllRounder => true,
            _ => false,
        };

    public static bool ForMobileArmor(this RoleType self) =>
        self switch
        {
            RoleType.Defender => true,
            RoleType.Assault => true,
            RoleType.Assistance => true,
            RoleType.Supply => true,
            RoleType.Disruption => true,
            RoleType.Combined => true,
            _ => false,
        };

}
