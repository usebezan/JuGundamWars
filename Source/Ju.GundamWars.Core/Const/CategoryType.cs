namespace Ju.GundamWars.Const;

public enum CategoryType : byte
{
    MobileSuit = 1,
    MobileArmor,
    Battleship,
    Pilot,
    Support,
    Cuspa,
    CoMobileSuit,
    CoMobileArmor,
    Unknown = 255,
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
            CategoryType.MobileSuit => GwText.MobileSuit,
            CategoryType.MobileArmor => GwText.MobileArmor,
            CategoryType.Battleship => GwText.Battleship,
            CategoryType.Pilot => GwText.Pilot,
            CategoryType.Support => GwText.Support,
            CategoryType.Cuspa => GwText.Cuspa,
            CategoryType.CoMobileSuit => GwText.CoMobileSuit,
            CategoryType.CoMobileArmor => GwText.CoMobileArmor,
            _ => GwText.Unknown,
        };

    public static string ToIcon(this CategoryType self) =>
        self switch
        {
            CategoryType.MobileSuit => GwIcon.MobileSuit,
            CategoryType.MobileArmor => GwIcon.MobileArmor,
            CategoryType.Battleship => GwIcon.Battleship,
            CategoryType.Pilot => GwIcon.Pilot,
            CategoryType.Support => GwIcon.Support,
            CategoryType.Cuspa => GwIcon.Cuspa,
            CategoryType.CoMobileSuit => GwIcon.CoMobileSuit,
            CategoryType.CoMobileArmor => GwIcon.CoMobileArmor,
            _ => GwIcon.Unknown,
        };

    public static bool ForCoMobile(this CategoryType self) =>
        self == CategoryType.MobileSuit;
    //self == CategoryType.MobileSuit || self == CategoryType.MobileArmor;

    public static bool ForCuspa(this CategoryType self) =>
        self == CategoryType.MobileSuit || self == CategoryType.Battleship;

    public static bool ForMobile(this CategoryType self) =>
        self == CategoryType.MobileSuit || self == CategoryType.MobileArmor;

    public static bool ForPilot(this CategoryType self) =>
        self == CategoryType.MobileSuit || self == CategoryType.MobileArmor;

    public static bool ForSupport(this CategoryType self) =>
        self == CategoryType.MobileSuit || self == CategoryType.MobileArmor;

}
