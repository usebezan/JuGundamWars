using Ju.GundamWars.BizMaster.Boosts.Domain;

namespace Ju.GundamWars.BizMaster.SupportSlots.Domain;

public record SupportSlotPrimitiveBase : ISupportSlotPrimitive
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
