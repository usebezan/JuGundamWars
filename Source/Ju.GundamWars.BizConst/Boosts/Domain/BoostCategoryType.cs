namespace Ju.GundamWars.BizConst.Boosts.Domain;

public enum BoostCategoryType : int
{
    None = 0,
    Mobile = 1,
    Pilot,
    Badge,
    Unknown = int.MaxValue,
}

public static class BoostCategoryTypeExtension
{

    public static BoostCategoryType ToBoostCategoryType(this int self)
    {
        try { return (BoostCategoryType)self; } catch { return BoostCategoryType.Unknown; }
    }

    public static int ToValue(this BoostCategoryType self) =>
        (int)self;

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
