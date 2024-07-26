using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportSlots.Domain;

public record SupportSlotBase : ISupportSlot
{

    #region Primitives

    public int Id { get; set; }
    public SupportSlotKindType SupportSlotKindType { get; set; }
    public BoostStatusType BoostStatusType { get; set; }
    public CalcMethodType CalcMethodType { get; set; }
    public int Value { get; set; }
    public int Order { get; set; }

    #endregion

}
