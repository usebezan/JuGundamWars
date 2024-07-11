using Ju.GundamWars.BizConst.Boosts.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;

namespace Ju.GundamWars.BizMaster.SupportSlots.Domain;

public record SupportSlot : BoostBase
{

    public SupportSlot(int Id, SupportSlotKindType Kind, BoostStatusType BoostStatus, CalcMethodType CalcMethod, decimal Value, int Order)
        : base(Kind switch
        {
            SupportSlotKindType.Normal => BoostCategoryType.None,
            SupportSlotKindType.Unlock => BoostCategoryType.Mobile,
            SupportSlotKindType.Bonus => BoostCategoryType.Badge,
            _ => BoostCategoryType.Unknown,
        }, BoostStatus, CalcMethod, Value)
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
