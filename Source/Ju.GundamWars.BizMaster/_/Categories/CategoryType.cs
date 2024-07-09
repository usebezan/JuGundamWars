namespace Ju.GundamWars.BizMaster._.Categories;

public enum CategoryType : byte
{
    // ユニット カテゴリ
    MobileSuit = 1,
    MobileArmor,
    Battleship,
    PilotMs,
    PilotMa,
    CoMobile,
    // ユニット（複合）カテゴリ
    Mobile = 21,
    Pilot,
    // カスパ カテゴリ
    NCuspaMobile0 = 61,
    NCuspaMobile1,
    NCuspaMobile2,
    NCuspaMobileSp1,
    NCuspaMobileSp2,
    NCuspaMobileSp3,
    SCuspaMobile,
    NCuspaBattleship0 = 91,
    NCuspaBattleship1,
    NCuspaBattleship2,
    // カスパ（複合）カテゴリ
    Cuspa = 121,
    NCuspa,
    // サポキャ カテゴリ
    SupportCharaMs = 151,
    SupportCharaMa,
    SupportSlot,
    SupportRelease,
    SupportBadge,
    // サポキャ（複合）カテゴリ
    SupportChara,

    Unknown = byte.MaxValue,
}

public static class CategoryTypeExtension
{

    public static CategoryType ToCategoryType(this byte self)
    {
        try { return (CategoryType)self; } catch { return CategoryType.Unknown; }
    }

    public static byte ToValue(this CategoryType self) =>
        (byte)self;

    public static string ToText(this CategoryType self) =>
        self switch
        {
            //CategoryType.MobileSuit => GwText.MobileSuit,
            //CategoryType.MobileArmor => GwText.MobileArmor,
            //CategoryType.Battleship => GwText.Battleship,
            //CategoryType.Pilot => GwText.Pilot,
            //CategoryType.CoMobile => GwText.CoMobile,
            //CategoryType.Mobile => GwText.Mobile,
            //CategoryType.NCuspa => GwText.NCuspa,
            //CategoryType.SCuspa => GwText.SCuspa,
            //CategoryType.Support => GwText.Support,
            //CategoryType.Badge => GwText.Badge,
            //CategoryType.Cuspa => GwText.Cuspa,
            _ => GwText.Unknown,
        };

    public static string ToIcon(this CategoryType self) =>
        self switch
        {
            //CategoryType.MobileSuit => GwIcon.MobileSuit,
            //CategoryType.MobileArmor => GwIcon.MobileArmor,
            //CategoryType.Battleship => GwIcon.Battleship,
            //CategoryType.Pilot => GwIcon.Pilot,
            //CategoryType.CoMobile => GwIcon.CoMobile,
            //CategoryType.Mobile => GwIcon.Mobile,
            //CategoryType.NCuspa => GwIcon.NCuspa,
            //CategoryType.SCuspa => GwIcon.SCuspa,
            //CategoryType.Support => GwIcon.Support,
            //CategoryType.Badge => GwIcon.Badge,
            //CategoryType.Cuspa => GwIcon.Cuspa,
            _ => GwIcon.Unknown,
        };

}
