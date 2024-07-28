namespace Ju.GundamWars.Share.Supports.Domain;

public record SupportSlotBadgeBase : ISupportSlotBadge
{

    #region Primitives

    public int SupportId { get; set; }
    public byte Seq { get; set; }
    public int SlotId { get; set; }
    public int? BadgeId { get; set; }

    #endregion

}
