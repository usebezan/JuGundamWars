namespace Ju.GundamWars.BizConst.Boosts.Domain;

public enum CalcMethodType : byte
{
    None = 0,
    Addition,
    Multiplication,
    Unknown = byte.MaxValue,
}

public static class CalcMethodTypeExtension
{

    public static CalcMethodType ToCalcMethodType(this byte self)
    {
        try { return (CalcMethodType)self; } catch { return CalcMethodType.Unknown; }
    }

    public static byte ToValue(this CalcMethodType self) =>
        (byte)self;

}
