using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Categories;

public enum CategoryType : byte
{
    MobileSuit = 1,
    MobileArmor,
    Battleship,
    Pilot,
    Support,
    Cuspa,
    CoUnitSuit,
    CoUnitArmor,
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
            CategoryType.MobileSuit => GwTextJp.MobileSuit,
            CategoryType.MobileArmor => GwTextJp.MobileArmor,
            CategoryType.Battleship => GwTextJp.Battleship,
            CategoryType.Pilot => GwTextJp.Pilot,
            CategoryType.Support => GwTextJp.Support,
            CategoryType.Cuspa => GwTextJp.Cuspa,
            CategoryType.CoUnitSuit => GwText.CoUnitSuit,
            CategoryType.CoUnitArmor => GwText.CoUnitArmor,
            _ => GwTextJp.Unknown,
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
            CategoryType.CoUnitSuit => GwIcon.CoUnitSuit,
            CategoryType.CoUnitArmor => GwIcon.CoUnitArmor,
            _ => GwIcon.Unknown,
        };

    public static bool ForCoUnit(this CategoryType self) =>
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
