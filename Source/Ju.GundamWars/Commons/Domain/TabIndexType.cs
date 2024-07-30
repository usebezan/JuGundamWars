namespace Ju.GundamWars.Commons.Domain;

public enum MenuIndexType : byte
{
    Mobile = 0,
    Pilot,
    Support,
    CoMobile,
    Cuspa,
    Tag,
    Unknown = byte.MaxValue,
}

public static class MenuIndexTypeExtension
{

    public static MenuIndexType ToMenuIndexType(this int self)
    {
        try { return (MenuIndexType)self; } catch { return MenuIndexType.Unknown; }
    }

    public static byte ToValue(this MenuIndexType self) =>
        (byte)self;

}
