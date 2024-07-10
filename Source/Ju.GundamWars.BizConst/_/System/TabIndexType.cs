namespace Ju.GundamWars.BizConst._.System;

public enum TabIndexType : byte
{
    Mobile = 0,
    Pilot,
    Support,
    CoMobile,
    Cuspa,
    Tag,
    Unknown = byte.MaxValue,
}

public static class TabIndexTypeExtension
{

    public static TabIndexType ToTabIndexType(this int self)
    {
        try { return (TabIndexType)self; } catch { return TabIndexType.Unknown; }
    }

    public static byte ToValue(this TabIndexType self) =>
        (byte)self;

}
