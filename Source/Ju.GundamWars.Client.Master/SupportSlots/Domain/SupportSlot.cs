using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;

namespace Ju.GundamWars.Client.SupportSlots.Domain;

public record SupportSlot : BoostBase, ISupportSlot
{

    #region Primitives

    public int Id { get; set; }
    public SupportSlotKindType SupportSlotKindType
    {
        get => __SupportSlotKindType;
        set
        {
            __SupportSlotKindType = value;
            BoostCategoryType = SupportSlotKindType switch
            {
                SupportSlotKindType.Normal => BoostCategoryType.None,
                SupportSlotKindType.Unlock => BoostCategoryType.Mobile,
                SupportSlotKindType.Bonus => BoostCategoryType.Badge,
                _ => BoostCategoryType.Unknown,
            };
        }
    }
    private SupportSlotKindType __SupportSlotKindType;
    public int Order { get; set; }

    #endregion

    #region Extensions

    public string Name => SupportSlotKindType == SupportSlotKindType.Normal ? "通常" : GetName();
    public bool IsAttachable => SupportSlotKindType == SupportSlotKindType.Bonus || SupportSlotKindType == SupportSlotKindType.Normal;
    public bool IsBonusable => SupportSlotKindType == SupportSlotKindType.Bonus;

    #endregion


    private string GetName()
    {
        if (BoostCategoryType == BoostCategoryType.Mobile)
        {
            return $"{BoostStatusType.ToText()} {BoostText}";
        }
        else if (BoostCategoryType == BoostCategoryType.Badge)
        {
            return $"{BoostStatusType.ToText()}バッジ {BoostText}";
        }
        else
        {
            return GwText.Unknown;
        }
    }

}
