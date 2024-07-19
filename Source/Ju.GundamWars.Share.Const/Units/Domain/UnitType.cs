namespace Ju.GundamWars.Share.Units.Domain;

[Flags]
public enum UnitType : byte
{
    MobileSuit = 1,
    MobileArmor = 2,
    Battleship = 4,
    Mobile = MobileSuit + MobileArmor,
    Unknown = 255,
}

public static class UnitTypeExtension
{

    public static UnitType ToUnitType(this byte self)
    {
        try { return (UnitType)self; } catch { return UnitType.Unknown; }
    }

    public static byte ToValue(this UnitType self) =>
        (byte)self;

    public static string ToText(this UnitType self) =>
        self switch
        {
            UnitType.MobileSuit => GwText.MobileSuit,
            UnitType.MobileArmor => GwText.MobileArmor,
            UnitType.Battleship => GwText.Battleship,
            UnitType.Mobile => GwText.Mobile,
            _ => GwText.Unknown,
        };

    public static string ToIcon(this UnitType self) =>
        self switch
        {
            UnitType.MobileSuit => GwIcon.MobileSuit,
            UnitType.MobileArmor => GwIcon.MobileArmor,
            UnitType.Battleship => GwIcon.Battleship,
            UnitType.Mobile => GwIcon.Mobile,
            _ => GwIcon.Unknown,
        };

}
