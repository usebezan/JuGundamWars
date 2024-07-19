namespace Ju.GundamWars.Share.AceImpls.Domain;

public enum AceImplType : byte
{
    Unimplemented = 1,
    Unpossession,
    Possession,
    Unknown = byte.MaxValue,
}

public static class AceImplTypeExtension
{

    public static AceImplType ToAceImplType(this byte self)
    {
        try { return (AceImplType)self; } catch { return AceImplType.Unknown; }
    }

    public static byte ToValue(this AceImplType self) =>
        (byte)self;

    public static string ToText(this AceImplType self) =>
        self switch
        {
            AceImplType.Unimplemented => "未実装",
            AceImplType.Unpossession => "未所持",
            AceImplType.Possession => "所持",
            _ => GwText.Unknown,
        };

}
