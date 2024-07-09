namespace Ju.GundamWars.BizMaster._.Categories;

public enum UnitCategoryType : byte
{
    MobileSuit = 1,
    MobileArmor,
    Battleship,
    PilotMs,
    PilotMa,
    CoMobile,
    Mobile = 101,
    Pilot,
    Unknown = byte.MaxValue,
}

public static class UnitCategoryTypeExtension
{

    public static UnitCategoryType ToUnitCategoryType(this byte self)
    {
        try { return (UnitCategoryType)self; } catch { return UnitCategoryType.Unknown; }
    }

    public static byte ToValue(this UnitCategoryType self) =>
        (byte)self;

    public static string ToText(this UnitCategoryType self) =>
        self switch
        {
            UnitCategoryType.MobileSuit => GwText.MobileSuit,
            UnitCategoryType.MobileArmor => GwText.MobileArmor,
            UnitCategoryType.Battleship => GwText.Battleship,
            UnitCategoryType.PilotMs => GwText.Pilot,
            UnitCategoryType.PilotMa => GwText.Pilot,
            UnitCategoryType.CoMobile => GwText.CoMobile,
            UnitCategoryType.Mobile => GwText.Mobile,
            UnitCategoryType.Pilot => GwText.Pilot,
            _ => GwText.Unknown,
        };

    public static string ToIcon(this UnitCategoryType self) =>
        self switch
        {
            UnitCategoryType.MobileSuit => GwIcon.MobileSuit,
            UnitCategoryType.MobileArmor => GwIcon.MobileArmor,
            UnitCategoryType.Battleship => GwIcon.Battleship,
            UnitCategoryType.PilotMs => GwIcon.Pilot,
            UnitCategoryType.PilotMa => GwIcon.Pilot,
            UnitCategoryType.CoMobile => GwIcon.CoMobile,
            UnitCategoryType.Mobile => GwIcon.Mobile,
            UnitCategoryType.Pilot => GwIcon.Pilot,
            _ => GwIcon.Unknown,
        };

}
