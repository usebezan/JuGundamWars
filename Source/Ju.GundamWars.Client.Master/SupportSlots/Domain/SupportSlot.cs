using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;

namespace Ju.GundamWars.Client.SupportSlots.Domain;

public record SupportSlot : BoostBase, ISupportSlot
{

    #region Primitives

    public int Id { get; set; }
    public SupportSlotKindType Kind
    {
        get => __Kind;
        set
        {
            __Kind = value;
            BoostCategory = Kind switch
            {
                SupportSlotKindType.Normal => BoostCategoryType.None,
                SupportSlotKindType.Unlock => BoostCategoryType.Mobile,
                SupportSlotKindType.Bonus => BoostCategoryType.Badge,
                _ => BoostCategoryType.Unknown,
            };
        }
    }
    private SupportSlotKindType __Kind;
    public int Order { get; set; }

    #endregion

    #region Extensions

    public string Name => Kind == SupportSlotKindType.Normal ? "通常" : GetName();
    public bool IsAttachable => Kind == SupportSlotKindType.Bonus || Kind == SupportSlotKindType.Normal;
    public bool IsBonusable => Kind == SupportSlotKindType.Bonus;

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
