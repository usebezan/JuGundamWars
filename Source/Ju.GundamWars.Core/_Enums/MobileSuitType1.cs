using System;


namespace Ju.GundamWars
{

    public enum MobileSuitType1 : byte
    {
        Normal = 1,
        Limited,
        Festival,
        Unknown = 255,
    }

    public static class MobileSuitType1Extension
    {

        public static MobileSuitType1 ToMobileSuitType1(this byte self)
        {
            try { return (MobileSuitType1)self; } catch { return MobileSuitType1.Unknown; };
        }

        public static byte ToValue(this MobileSuitType1 self) =>
            (byte)self;

        public static string ToText(this MobileSuitType1 self) =>
            self switch
            {
                MobileSuitType1.Normal => "通常",
                MobileSuitType1.Limited => "限定",
                MobileSuitType1.Festival => "フェス限",
                _ => "Unknown",
            };

    }

}
