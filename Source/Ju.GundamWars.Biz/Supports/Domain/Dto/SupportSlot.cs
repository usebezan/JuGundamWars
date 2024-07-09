using Ju.GundamWars.BizMaster.SupportSlotKinds;
using Ju.GundamWars.Core.Common.Domain;
using Ju.GundamWars.Core.Ju.GundamWars;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Boosts;
using Ju.GundamWars.Core.Ju.GundamWars.System;

namespace Ju.GundamWars.Supports.Domain.Entities;

public class SupportSlot : IIdentify, IBooster
{

    public int Id { get; set; }
    public SupportSlotKindType Kind { get; set; }
    public BoostStatusType Boost { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    public string Name => Kind == SupportSlotKindType.Normal ? "通常" : GetName();
    public string BoostText => Kind == SupportSlotKindType.Normal ? "通常" : Boost.ToText();
    public BoostUnitType BoostTarget => Boost.ToBoostUnitType();
    public bool IsAttachable => Kind == SupportSlotKindType.Bonus || Kind == SupportSlotKindType.Normal;
    public bool IsBonusable => Kind == SupportSlotKindType.Bonus;


    private string GetName()
    {
        if (BoostTarget == BoostUnitType.Mobile)
        {
            return $"{Boost.ToStatusText()} {this.GetUpText()}";
        }
        else if (BoostTarget == BoostUnitType.Badge)
        {
            return $"{Boost.ToStatusText()}バッジ {this.GetUpText()}";
        }
        else
        {
            return GwText.Unknown;
        }
    }

}
