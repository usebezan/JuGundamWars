namespace Ju.GundamWars.BizMaster._.Boosts;

public enum BoostUnitType : byte
{
    Mobile = 1,
    Pilot,
    Badge,
    Unknown = byte.MaxValue,
}

public static class BoostUnitTypeExtension
{

    public static BoostUnitType ToBoostUnitType(this byte self)
    {
        try { return (BoostUnitType)self; } catch { return BoostUnitType.Unknown; }
    }

    public static byte ToValue(this BoostUnitType self) =>
        (byte)self;

    public static string ToText(this BoostUnitType self) =>
        self switch
        {
            BoostUnitType.Mobile => GwText.Mobile,
            BoostUnitType.Pilot => GwText.Pilot,
            BoostUnitType.Badge => GwText.Badge,
            _ => GwText.Unknown,
        };

}
