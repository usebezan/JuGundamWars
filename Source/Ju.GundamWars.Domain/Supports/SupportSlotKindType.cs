using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Supports;

public enum SupportSlotKindType : byte
{
    Normal = 1,
    Unlock,
    Bonus,
    Unknown = 255,
}

public static class SupportSlotKindTypeExtension
{

    public static SupportSlotKindType ToSupportSlotType(this byte self)
    {
        try { return (SupportSlotKindType)self; } catch { return SupportSlotKindType.Unknown; }
    }

    public static byte ToValue(this SupportSlotKindType self) =>
        (byte)self;

    public static string ToText(this SupportSlotKindType self) =>
        self switch
        {
            SupportSlotKindType.Normal => "通常",
            SupportSlotKindType.Unlock => "解放",
            SupportSlotKindType.Bonus => "ボーナス",
            _ => GwTextJp.Unknown,
        };

}
