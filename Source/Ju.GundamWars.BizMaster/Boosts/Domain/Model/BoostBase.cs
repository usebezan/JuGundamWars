namespace Ju.GundamWars.BizMaster.Boosts.Domain.Model;

public record BoostBase : IBooster
{

    public BoostBase(BoostCategoryType BoostCategory, BoostStatusType BoostStatus, CalcType Calc, decimal Value)
    {
        this.BoostCategory = BoostCategory;
        this.BoostStatus = BoostStatus;
        this.Calc = Calc;
        this.Value = Value;
        TargetText = GetTargetText();
        BoostText = GetBoostText();
    }


    public BoostCategoryType BoostCategory { get; }
    public BoostStatusType BoostStatus { get; }
    public CalcType Calc { get; }
    public decimal Value { get; }
    public string TargetText { get; }
    public string BoostText { get; }


    public int CalcBoostedValue(int baseValue = 0)
    {
        if (Calc == CalcType.Addition)
        {
            return baseValue + decimal.ToInt32(Value);
        }
        else if (Calc == CalcType.Multiplication)
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
        if (Calc == CalcType.None) return GwText.None;
        if (Calc == CalcType.Addition) return $"+{Value}";
        if (Calc == CalcType.Multiplication)
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
