using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Share.SupportSlots.Domain;

public interface ISupportSlot : IIdentifiable, IOrderable
{

    #region Primitives

    SupportSlotKindType SupportSlotKindType { get; set; }
    BoostStatusType BoostStatusType { get; set; }
    CalcMethodType CalcMethodType { get; set; }
    int Value { get; set; }

    #endregion

}
