using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.BizMaster.Boosts.Domain.Model;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizMaster.Terrains.Domain;

namespace Ju.GundamWars.BizMaster.SupportSlots.Domain.Model;

public record SupportSlot : BoostBase
{

    public SupportSlot(int Id, SupportSlotKindType Kind, BoostStatusType BoostStatus, CalcType Calc, decimal Value, int Order)
        : base(Kind switch
        {
            SupportSlotKindType.Normal => BoostCategoryType.None,
            SupportSlotKindType.Unlock => BoostCategoryType.Mobile,
            SupportSlotKindType.Bonus => BoostCategoryType.Badge,
            _ => BoostCategoryType.Unknown,
        }, BoostStatus, Calc, Value)
    {
        this.Id = Id;
        this.Kind = Kind;
        this.Order = Order;
        Name = Kind == SupportSlotKindType.Normal ? "通常" : GetName();
        IsAttachable = Kind == SupportSlotKindType.Bonus || Kind == SupportSlotKindType.Normal;
        IsBonusable = Kind == SupportSlotKindType.Bonus;
    }


    #region Primitives

    public int Id { get; }
    public SupportSlotKindType Kind { get; }
    public int Order { get; }

    #endregion

    #region Extensions

    public string Name { get; }
    public bool IsAttachable { get; }
    public bool IsBonusable { get; }

    #endregion


    private string GetName()
    {
        if (BoostCategory == BoostCategoryType.Mobile)
        {
            return $"{BoostStatus.ToText()} {BoostText}";
        }
        else if (BoostCategory == BoostCategoryType.Badge)
        {
            return $"{BoostStatus.ToText()}バッジ {BoostText}";
        }
        else
        {
            return GwText.Unknown;
        }
    }

}
