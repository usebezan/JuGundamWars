using System;


namespace Ju.GundamWars
{

    public enum MobileArmorRoleType : byte
    {
        Defensive = 1,
        Offensive,
        Support,
        Recovery,
        Disruptive,
        AllRounder,
        Unknown = 255,
    }

    public static class MobileArmorRoleTypeExtension
    {

        public static MobileArmorRoleType ToMobileArmorRoleType(this byte self)
        {
            try { return (MobileArmorRoleType)self; } catch { return MobileArmorRoleType.Unknown; };
        }

        public static byte ToValue(this MobileArmorRoleType self) =>
            (byte)self;

        public static string ToText(this MobileArmorRoleType self) =>
            self switch
            {
                MobileArmorRoleType.Defensive => "防衛型",
                MobileArmorRoleType.Offensive => "攻撃型",
                MobileArmorRoleType.Support => "支援型",
                MobileArmorRoleType.Recovery => "回復型",
                MobileArmorRoleType.Disruptive => "妨害型",
                MobileArmorRoleType.AllRounder => "万能型",
                _ => "Unknown",
            };

    }

}
