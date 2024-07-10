namespace Ju.GundamWars.BizMaster.Boosts.Domain;

public enum CalcType : byte
{
    None = 0,
    Addition,
    Multiplication,
    Unknown = byte.MaxValue,
}

public static class CalcTypeExtension
{

    public static CalcType ToCalcType(this byte self)
    {
        try { return (CalcType)self; } catch { return CalcType.Unknown; }
    }

    public static byte ToValue(this CalcType self) =>
        (byte)self;

}
