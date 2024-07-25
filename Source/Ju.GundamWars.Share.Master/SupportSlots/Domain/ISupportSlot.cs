using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportSlots.Domain;

public interface ISupportSlot : IIdentifiable, IOrderable
{

    #region Primitives

    SupportSlotKindType Kind { get; set; }
    BoostStatusType BoostStatus { get; set; }
    CalcMethodType CalcMethod { get; set; }
    int Value { get; set; }

    #endregion

}
