using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Boosts;

[Flags]
public enum BoostTargetType : int
{
    None = 0,
    Mobile = GwConst.MobileFlag,
    Pilot = GwConst.PilotFlag,
    Badge = GwConst.BadgeFlag,
    Unknown = int.MaxValue,
}

public static class BoostTargetTypeExtension
{

    public static BoostTargetType ToBoostTargetType(this int self)
    {
        try { return (BoostTargetType)self; } catch { return BoostTargetType.Unknown; }
    }

    public static int ToValue(this BoostTargetType self) =>
        (int)self;

    public static string ToText(this BoostTargetType self) =>
        self switch
        {
            BoostTargetType.None => GwTextJp.None,
            BoostTargetType.Mobile => "機体",
            BoostTargetType.Pilot => "パイロット",
            BoostTargetType.Badge => "バッジ",
            _ => GwTextJp.Unknown,
        };

}
