using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Supports.Entities;

public class SupportSlot : IIdentify, IBooster
{

    public int Id { get; set; }
    public SupportSlotKindType Kind { get; set; }
    public BoostType Boost { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    public string Name => Kind == SupportSlotKindType.Normal ? "通常" : GetName();
    public string BoostText => Kind == SupportSlotKindType.Normal ? "通常" : Boost.ToText();
    public BoostTargetType BoostTarget => Boost.ToBoostTargetType();
    public bool IsAttachable => Kind == SupportSlotKindType.Bonus || Kind == SupportSlotKindType.Normal;
    public bool IsBonusable => Kind == SupportSlotKindType.Bonus;


    private string GetName()
    {
        if (BoostTarget == BoostTargetType.Mobile)
        {
            return $"{Boost.ToStatusText()} {this.GetUpText()}";
        }
        else if (BoostTarget == BoostTargetType.Badge)
        {
            return $"{Boost.ToStatusText()}バッジ {this.GetUpText()}";
        }
        else
        {
            return GwText.Unknown;
        }
    }

}
