namespace Ju.GundamWars.BizConst.Positions.Domain;

public enum PositionType : byte
{
    Front = 1,
    Rear,
    Unknown = byte.MaxValue,
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
            _ => GwText.Unknown,
        };

    public static string ToIcon(this PositionType self) =>
        self switch
        {
            PositionType.Front => "ArrowRightBoldBoxOutline",
            PositionType.Rear => "ArrowLeftBoldBoxOutline",
            _ => GwIcon.Unknown,
        };

}
