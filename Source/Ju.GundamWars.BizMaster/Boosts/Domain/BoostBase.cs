namespace Ju.GundamWars.BizMaster.Boosts.Domain;

public record BoostBase : IBooster
{

    #region Primitives

    public BoostCategoryType BoostCategory { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public int Value { get; set; }

    #endregion

    #region Extensions

    public string TargetText => GetTargetText();
    public string BoostText => GetBoostText();

    #endregion


    public int CalcBoostedValue(int baseValue = 0)
    {
        if (CalcMethod == CalcMethodType.Addition)
        {
            return baseValue + Value;
        }
        else if (CalcMethod == CalcMethodType.Multiplication)
        {
            return baseValue.Multiply1k(Value);
        }
        return baseValue;
    }

    private string GetTargetText()
    {
        if (BoostCategory == BoostCategoryType.None && BoostStatus == BoostStatusType.None) return GwText.None;
        if (BoostCategory == BoostCategoryType.Unknown && BoostStatus == BoostStatusType.Unknown) return GwText.Unknown;
        return $"{BoostCategory.ToText()} の {BoostStatus.ToText()}";
    }

    private string GetBoostText()
    {
        if (CalcMethod == CalcMethodType.None) return GwText.None;
        if (CalcMethod == CalcMethodType.Addition) return $"+{Value}";
        if (CalcMethod == CalcMethodType.Multiplication)
        {
            var value = Value / 10m;
            if (value % 1 == 0)
            {
                return $"{value:F0}% UP";
            }
            else
            {
                return $"{value.ToString($"F3").TrimEnd('0')}% UP";
            }
        }
        return GwText.Unknown;
    }

}
