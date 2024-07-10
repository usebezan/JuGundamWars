using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.SupportSlots.Domain.Dto;

public class SupportSlotDto : IIdentify
{

    #region Primitives

    public int Id { get; set; }
    public SupportSlotKindType Kind { get; set; }
    public BoostStatusType BoostStatus { get; set; }
    public CalcType Calc { get; set; }
    public decimal Value { get; set; }
    public int Order { get; set; }

    #endregion

}
