namespace Ju.GundamWars.BizConst.CuspaKinds.Domain;

public enum CuspaKindType : byte
{
    Normal1 = 1,
    Normal2,
    Normal3,

    Special1 = 11,
    Special2,
    Special3,

    Super1 = 21,

    Unknown = byte.MaxValue,
}

public static class CuspaGroupTypeExtension
{

    public static CuspaKindType ToCuspaGroupType(this byte self)
    {
        try { return (CuspaKindType)self; } catch { return CuspaKindType.Unknown; }
    }

    public static byte ToValue(this CuspaKindType self) =>
        (byte)self;

    public static string ToText(this CuspaKindType self) =>
        self switch
        {
            CuspaKindType.Normal1 => "ノーマル",
            CuspaKindType.Normal2 => "ノーマル+",
            CuspaKindType.Normal3 => "ノーマル++",

            CuspaKindType.Special1 => "特殊Ⅰ",
            CuspaKindType.Special2 => "特殊Ⅱ",
            CuspaKindType.Special3 => "特殊Ⅲ",

            CuspaKindType.Super1 => "S（Super）",

            _ => GwText.Unknown,
        };

    public static string ToSurffix(this CuspaKindType self) =>
        self switch
        {
            CuspaKindType.Normal1 => "",
            CuspaKindType.Normal2 => "+",
            CuspaKindType.Normal3 => "++",

            CuspaKindType.Special1 => "特殊Ⅰ",
            CuspaKindType.Special2 => "特殊Ⅱ",
            CuspaKindType.Special3 => "特殊Ⅲ",

            CuspaKindType.Super1 => "【S】",

            _ => GwText.Unknown,
        };

    public static bool ForMoblieNormal(this CuspaKindType self) =>
        self == CuspaKindType.Normal1 ||
        self == CuspaKindType.Normal2 ||
        self == CuspaKindType.Normal3 ||
        self == CuspaKindType.Special1 ||
        self == CuspaKindType.Special2 ||
        self == CuspaKindType.Special3;

    public static bool ForMoblieSuper(this CuspaKindType self) =>
        self == CuspaKindType.Super1;

    public static bool ForBattleshipNormal(this CuspaKindType self) =>
        self == CuspaKindType.Normal1 ||
        self == CuspaKindType.Normal2 ||
        self == CuspaKindType.Normal3;

}
