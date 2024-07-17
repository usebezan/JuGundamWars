namespace Ju.GundamWars.BizMaster.Boosts.Domain;

public enum BoostCategoryType : byte
{
    None = 0,
    Mobile = 1,
    Pilot,
    Badge,
    Unknown = byte.MaxValue,
}

public static class BoostCategoryTypeExtension
{

    public static BoostCategoryType ToBoostCategoryType(this byte self)
    {
        try { return (BoostCategoryType)self; } catch { return BoostCategoryType.Unknown; }
    }

    public static byte ToValue(this BoostCategoryType self) =>
        (byte)self;

    public static string ToText(this BoostCategoryType self) =>
        self switch
        {
            BoostCategoryType.None => GwText.None,
            BoostCategoryType.Mobile => "機体",
            BoostCategoryType.Pilot => "パイロット",
            BoostCategoryType.Badge => "バッジ",
            _ => GwText.Unknown,
        };

}
