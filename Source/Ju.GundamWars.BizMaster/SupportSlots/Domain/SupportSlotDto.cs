using Ju.GundamWars.BizConst.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.SupportSlots.Domain;

public class SupportSlotDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public SupportSlotKindType Kind { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcMethodType CalcMethod { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    #endregion

}
