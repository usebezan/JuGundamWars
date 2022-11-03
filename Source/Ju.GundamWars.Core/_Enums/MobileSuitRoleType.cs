using System;


namespace Ju.GundamWars
{

    public enum MobileSuitRoleType : byte
    {
        Defensive = 1,
        Offensive,
        Support,
        Recovery,
        Disruptive,
        AllRounder,
        Unknown = 255,
    }

    public static class MobileSuitRoleTypeExtension
    {

        public static MobileSuitRoleType ToMobileSuitRoleType(this byte self)
        {
            try { return (MobileSuitRoleType)self; } catch { return MobileSuitRoleType.Unknown; };
        }

        public static byte ToValue(this MobileSuitRoleType self) =>
            (byte)self;

        public static string ToText(this MobileSuitRoleType self) =>
            self switch
            {
                MobileSuitRoleType.Defensive => "防衛型",
                MobileSuitRoleType.Offensive => "攻撃型",
                MobileSuitRoleType.Support => "支援型",
                MobileSuitRoleType.Recovery => "回復型",
                MobileSuitRoleType.Disruptive => "妨害型",
                MobileSuitRoleType.AllRounder => "万能型",
                _ => "Unknown",
            };

    }

}
