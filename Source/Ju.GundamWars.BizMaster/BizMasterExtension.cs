using Ju.GundamWars.BizMaster.System;

namespace Ju.GundamWars.BizMaster;

public static class BizMasterExtension
{

    public static int Multiply(this int self, decimal multiplier) =>
        (int)Math.Floor(self * multiplier);

    public static string GetUpText(this IBooster self)
    {
        if (self.Calc == CalcType.Addition)
        {
            return $"+{self.Value}";
        }
        else if (self.Calc == CalcType.Multiplication)
        {
            var value = self.Value * 100;
            if (value % 1 == 0)
            {
                return $"{value:F0}% UP";
            }
            else
            {
                return $"{value.ToString($"F3").TrimEnd('0')}% UP";
            }
        }
        else
        {
            return GwText.Unknown;
        }
    }

}
