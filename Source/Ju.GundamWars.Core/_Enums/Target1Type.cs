using System;


namespace Ju.GundamWars
{

    public enum Target1Type : byte
    {
        None = 0,
        Unit,
        Pilot,
        Badge,
        Unknown = 255,
    }


    public static class Target1TypeExtension
    {

        public static Target1Type ToTarget1Type(this byte self)
        {
            try { return (Target1Type)self; } catch { return Target1Type.Unknown; }
        }

        public static byte ToValue(this Target1Type self) =>
            (byte)self;

        public static string ToText(this Target1Type self) =>
            self switch
            {
                Target1Type.None => "なし",
                Target1Type.Unit => "機体",
                Target1Type.Pilot => "パイロット",
                Target1Type.Badge => "バッジ",
                _ => "不明",
            };

    }

}
