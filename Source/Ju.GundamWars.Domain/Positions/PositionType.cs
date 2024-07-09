using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Positions;

public enum PositionType : byte
{
    Front = 1,
    Rear,
    Unknown = 255,
}

public static class PositionTypeExtension
{

    public static PositionType ToPositionType(this byte self)
    {
        try { return (PositionType)self; } catch { return PositionType.Unknown; }
    }

    public static byte ToValue(this PositionType self) =>
        (byte)self;

    public static string ToText(this PositionType self) =>
        self switch
        {
            PositionType.Front => "前衛",
            PositionType.Rear => "後衛",
            _ => GwTextJp.Unknown,
        };

    public static string ToIcon(this PositionType self) =>
        self switch
        {
            PositionType.Front => "ArrowRightBoldBoxOutline",
            PositionType.Rear => "ArrowLeftBoldBoxOutline",
            _ => GwIcon.Unknown,
        };

}
