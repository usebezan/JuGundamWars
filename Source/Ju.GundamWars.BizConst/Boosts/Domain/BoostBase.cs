namespace Ju.GundamWars.BizConst.Boosts.Domain;

public record BoostBase : IBooster
{

    public BoostBase(BoostCategoryType BoostCategory, BoostStatusType BoostStatus, CalcMethodType CalcMethod, decimal Value)
    {
        this.BoostCategory = BoostCategory;
        this.BoostStatus = BoostStatus;
        this.CalcMethod = CalcMethod;
        this.Value = Value;
        TargetText = GetTargetText();
        BoostText = GetBoostText();
    }


    public BoostCategoryType BoostCategory { get; }
    public BoostStatusType BoostStatus { get; }
    public CalcMethodType CalcMethod { get; }
    public decimal Value { get; }
    public string TargetText { get; }
    public string BoostText { get; }


    public int CalcBoostedValue(int baseValue = 0)
    {
        if (CalcMethod == CalcMethodType.Addition)
        {
            return baseValue + decimal.ToInt32(Value);
        }
        else if (CalcMethod == CalcMethodType.Multiplication)
        {
            return baseValue.Multiply(Value);
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
            var value = Value * 100;
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
