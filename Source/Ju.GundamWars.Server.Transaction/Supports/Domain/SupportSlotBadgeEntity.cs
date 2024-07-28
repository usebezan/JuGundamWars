using Ju.GundamWars.Server.SupportBadges.Domain;
using Ju.GundamWars.Server.SupportSlots.Domain;
using Ju.GundamWars.Share.Supports.Domain;

namespace Ju.GundamWars.Server.Supports.Domain;

public record SupportSlotBadgeEntity : SupportSlotBadgeBase
{

    #region Navigations

    public SupportEntity? Support { get; set; }
    public SupportSlotEntity? SupportSlot { get; set; }
    public SupportBadgeEntity? SupportBadge { get; set; }

    #endregion

}
