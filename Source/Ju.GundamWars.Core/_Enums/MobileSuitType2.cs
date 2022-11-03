using System;


namespace Ju.GundamWars
{

    public enum MobileSuitType2 : byte
    {
        None = 0,
        Medal,
        Transform,
        Lethal,
        Combination,
        Unknown = 255,
    }

    public static class MobileSuitType2Extension
    {

        public static MobileSuitType2 ToMobileSuitType2(this byte self)
        {
            try { return (MobileSuitType2)self; } catch { return MobileSuitType2.Unknown; };
        }

        public static byte ToValue(this MobileSuitType2 self) =>
            (byte)self;

        public static string ToText(this MobileSuitType2 self) =>
            self switch
            {
                MobileSuitType2.None => "なし",
                MobileSuitType2.Medal => "メダル",
                MobileSuitType2.Transform => "換装",
                MobileSuitType2.Lethal => "リーサル",
                MobileSuitType2.Combination => "コンビ",
                _ => "Unknown",
            };

    }

}
