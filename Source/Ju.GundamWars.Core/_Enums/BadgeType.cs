using System;


namespace Ju.GundamWars
{

    public enum BadgeType : byte
    {
        Normal = 1,
        Special,
        Event,
        Unknown = 255,
    }


    public static class BadgeTypeExtension
    {

        public static BadgeType ToBadgeType(this byte self)
        {
            try { return (BadgeType)self; } catch { return BadgeType.Unknown; }
        }

        public static byte ToValue(this BadgeType self) =>
            (byte)self;

        public static string ToText(this BadgeType self) =>
            self switch
            {
                BadgeType.Normal => "通常",
                BadgeType.Special => "特殊",
                BadgeType.Event => "イベント",
                _ => "不明",
            };

    }

}
