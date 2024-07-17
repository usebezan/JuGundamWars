using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.SupportSlots.Domain;

public interface ISupportSlotPrimitive : IIdentify, IOrderable
{

    #region Primitives

    SupportSlotKindType Kind { get; set; }
    BoostStatusType BoostStatus { get; set; }
    CalcMethodType CalcMethod { get; set; }
    int Value { get; set; }

    #endregion

}
