using System;


namespace Ju.GundamWars
{

    public enum SlotType : byte
    {
        Normal = 1,
        Unlock,
        Bonus,
        Unknown = 255,
    }


    public static class SlotTypeExtension
    {

        public static SlotType ToSlotType(this byte self)
        {
            try { return (SlotType)self; } catch { return SlotType.Unknown; }
        }

        public static byte ToValue(this SlotType self) =>
            (byte)self;

        public static string ToText(this SlotType self) =>
            self switch
            {
                SlotType.Normal => "通常",
                SlotType.Unlock => "解放",
                SlotType.Bonus => "ボーナス",
                _ => "不明",
            };

    }

}
