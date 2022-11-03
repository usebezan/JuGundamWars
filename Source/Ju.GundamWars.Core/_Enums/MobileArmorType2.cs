using System;


namespace Ju.GundamWars
{

    public enum MobileArmorType2 : byte
    {
        None = 0,
        Medal,
        Transform,
        Lethal,
        Combination,
        Unknown = 255,
    }

    public static class MobileArmorType2Extension
    {

        public static MobileArmorType2 ToMobileArmorType2(this byte self)
        {
            try { return (MobileArmorType2)self; } catch { return MobileArmorType2.Unknown; };
        }

        public static byte ToValue(this MobileArmorType2 self) =>
            (byte)self;

        public static string ToText(this MobileArmorType2 self) =>
            self switch
            {
                MobileArmorType2.None => "なし",
                MobileArmorType2.Medal => "メダル",
                MobileArmorType2.Transform => "換装",
                MobileArmorType2.Lethal => "リーサル",
                MobileArmorType2.Combination => "コンビ",
                _ => "Unknown",
            };

    }

}
