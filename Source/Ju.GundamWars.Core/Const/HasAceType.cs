namespace Ju.GundamWars.Const;

public enum HasAceType : byte
{
    Unimplemented = 1,
    Unpossession,
    Possession,
    Unknown = 255,
}

public static class HasAceTypeExtension
{

    public static HasAceType ToHasAceType(this byte self)
    {
        try { return (HasAceType)self; } catch { return HasAceType.Unknown; }
    }

    public static byte ToValue(this HasAceType self) =>
        (byte)self;

    public static string ToText(this HasAceType self) =>
        self switch
        {
            HasAceType.Unimplemented => "未実装",
            HasAceType.Unpossession => "未所持",
            HasAceType.Possession => "所持",
            _ => GwText.Unknown,
        };

}
