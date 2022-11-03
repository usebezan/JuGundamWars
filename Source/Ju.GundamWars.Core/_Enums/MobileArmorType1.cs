using System;


namespace Ju.GundamWars
{

    public enum MobileArmorType1 : byte
    {
        Normal = 1,
        Limited,
        Festival,
        Unknown = 255,
    }

    public static class MobileArmorType1Extension
    {

        public static MobileArmorType1 ToMobileArmorType1(this byte self)
        {
            try { return (MobileArmorType1)self; } catch { return MobileArmorType1.Unknown; };
        }

        public static byte ToValue(this MobileArmorType1 self) =>
            (byte)self;

        public static string ToText(this MobileArmorType1 self) =>
            self switch
            {
                MobileArmorType1.Normal => "通常",
                MobileArmorType1.Limited => "限定",
                MobileArmorType1.Festival => "フェス限",
                _ => "Unknown",
            };

    }

}
