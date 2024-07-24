using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportSlots.Domain;

public record SupportSlotBase : ISupportSlot
{

    #region Primitives

    public int Id { get; set; }
    public SupportSlotKindType Kind { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public int Value { get; set; }
    public int Order { get; set; }

    #endregion

}
