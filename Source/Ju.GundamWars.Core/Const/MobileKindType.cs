namespace Ju.GundamWars.Const;

public enum MobileKindType : byte
{
    Normal = 1,
    Limited,
    Ex,
    Change,
    Lethal,
    Combi,
    Unknown = 255,
}

public static class MobileKindTypeExtension
{

    public static MobileKindType ToMobileKindType(this byte self)
    {
        try { return (MobileKindType)self; } catch { return MobileKindType.Unknown; }
    }

    public static byte ToValue(this MobileKindType self) =>
        (byte)self;

    public static string ToText(this MobileKindType self) =>
        self switch
        {
            MobileKindType.Normal => "通常",
            MobileKindType.Limited => "限定",
            MobileKindType.Ex => "メダル",
            MobileKindType.Change => "換装",
            MobileKindType.Lethal => "リーサル",
            MobileKindType.Combi => "コンビ",
            _ => GwText.Unknown,
        };

}
