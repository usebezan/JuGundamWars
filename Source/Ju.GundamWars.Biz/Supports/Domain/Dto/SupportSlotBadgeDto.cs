using Ju.GundamWars.BizMaster.SupportBadges.Domain.Dto;
using Ju.GundamWars.BizMaster.SupportSlots.Domain.Dto;

namespace Ju.GundamWars.Biz.Supports.Domain.Dto;

public class SupportSlotBadgeDto
{

    #region Primitives

    public int SupportId { get; set; }
    public byte Seq { get; set; }
    public int SlotId { get; set; }
    public int? BadgeId { get; set; }

    #endregion

    #region Navigations

    public SupportDto? Support { get; set; }
    public SupportSlotDto? Slot { get; set; }
    public SupportBadgeDto? Badge { get; set; }

    #endregion

}
