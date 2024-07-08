namespace Ju.GundamWars.Const;

public enum TagKindType : byte
{
    Mobile = 1,
    Battleship,
    Pilot,
    Support,
    Cuspa,
    CoMobile,
    Unknown = 255,
}

public static class TagKindTypeExtension
{

    public static TagKindType ToTagKindType(this byte self)
    {
        try { return (TagKindType)self; } catch { return TagKindType.Unknown; }
    }

    public static byte ToValue(this TagKindType self) =>
        (byte)self;

    public static string ToText(this TagKindType self) =>
        self switch
        {
            TagKindType.Mobile => "MS・MA",
            TagKindType.Battleship => "戦艦",
            TagKindType.Pilot => "パイロット",
            TagKindType.Support => "サポキャ",
            TagKindType.Cuspa => "カスパ",
            TagKindType.CoMobile => "連携",
            _ => GwText.Unknown,
        };

    public static bool ForMobile(this TagKindType self) =>
        self == TagKindType.Mobile;

    public static bool ForBattleship(this TagKindType self) =>
        self == TagKindType.Battleship;

    public static bool ForPilot(this TagKindType self) =>
        self == TagKindType.Pilot;

    public static bool ForSupport(this TagKindType self) =>
        self == TagKindType.Support;

    public static bool ForCuspa(this TagKindType self) =>
        self == TagKindType.Cuspa;

    public static bool ForCoMobile(this TagKindType self) =>
        self == TagKindType.CoMobile;

}
