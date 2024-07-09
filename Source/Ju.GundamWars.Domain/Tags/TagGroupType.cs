using Ju.GundamWars.Domain.System;

namespace Ju.GundamWars.Domain.Tags;

public enum TagGroupType : byte
{
    Mobile = 1,
    Battleship,
    Pilot,
    Support,
    Cuspa,
    CoUnit,
    Unknown = 255,
}

public static class TagGroupTypeExtension
{

    public static TagGroupType ToTagGroupType(this byte self)
    {
        try { return (TagGroupType)self; } catch { return TagGroupType.Unknown; }
    }

    public static byte ToValue(this TagGroupType self) =>
        (byte)self;

    public static string ToText(this TagGroupType self) =>
        self switch
        {
            TagGroupType.Mobile => GwTextJp.Mobile,
            TagGroupType.Battleship => GwTextJp.Battleship,
            TagGroupType.Pilot => GwTextJp.Pilot,
            TagGroupType.Support => GwTextJp.Support,
            TagGroupType.Cuspa => GwTextJp.Cuspa,
            TagGroupType.CoUnit => GwTextJp.CoUnit,
            _ => GwTextJp.Unknown,
        };

    public static bool ForMobile(this TagGroupType self) =>
        self == TagGroupType.Mobile;

    public static bool ForBattleship(this TagGroupType self) =>
        self == TagGroupType.Battleship;

    public static bool ForPilot(this TagGroupType self) =>
        self == TagGroupType.Pilot;

    public static bool ForSupport(this TagGroupType self) =>
        self == TagGroupType.Support;

    public static bool ForCuspa(this TagGroupType self) =>
        self == TagGroupType.Cuspa;

    public static bool ForCoUnit(this TagGroupType self) =>
        self == TagGroupType.CoUnit;

}
