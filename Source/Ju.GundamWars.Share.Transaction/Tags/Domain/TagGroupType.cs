namespace Ju.GundamWars.Share.Tags.Domain;

public enum TagGroupType : byte
{
    Mobile = 1,
    Battleship,
    Pilot,
    Support,
    Cuspa,
    CoMobile,
    Unknown = byte.MaxValue,
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
            TagGroupType.Mobile => GwText.Mobile,
            TagGroupType.Battleship => GwText.Battleship,
            TagGroupType.Pilot => GwText.Pilot,
            TagGroupType.Support => GwText.Support,
            TagGroupType.Cuspa => GwText.Cuspa,
            TagGroupType.CoMobile => GwText.CoMobile,
            _ => GwText.Unknown,
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

    public static bool ForCoMobile(this TagGroupType self) =>
        self == TagGroupType.CoMobile;

}
