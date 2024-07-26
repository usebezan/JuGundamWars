namespace Ju.GundamWars.Share.Boosts.Domain;

public abstract record BoostBase
{

    #region Primitives

    public BoostCategoryType BoostCategoryType { get; set; }
    public BoostStatusType BoostStatusType { get; set; }
    public CalcMethodType CalcMethodType { get; set; }
    public int Value { get; set; }

    #endregion

    #region Extensions

    public string TargetText => GetTargetText();
    public string BoostText => GetBoostText();

    #endregion


    public int CalcBoostedValue(int baseValue = 0)
    {
        if (CalcMethodType == CalcMethodType.Addition)
        {
            return baseValue + Value;
        }
        else if (CalcMethodType == CalcMethodType.Multiplication)
        {
            return baseValue.Multiply1k(Value);
        }
        return baseValue;
    }

    private string GetTargetText()
    {
        if (BoostCategoryType == BoostCategoryType.None && BoostStatusType == BoostStatusType.None) return GwText.None;
        if (BoostCategoryType == BoostCategoryType.Unknown && BoostStatusType == BoostStatusType.Unknown) return GwText.Unknown;
        return $"{BoostCategoryType.ToText()} の {BoostStatusType.ToText()}";
    }

    private string GetBoostText()
    {
        if (CalcMethodType == CalcMethodType.None) return GwText.None;
        if (CalcMethodType == CalcMethodType.Addition) return $"+{Value}";
        if (CalcMethodType == CalcMethodType.Multiplication)
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
