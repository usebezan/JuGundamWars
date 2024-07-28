namespace Ju.GundamWars.Share.Supports.Domain;

public record SupportSlotBadgeBase : ISupportSlotBadge
{

    #region Primitives

    public int SupportId { get; set; }
    public byte Seq { get; set; }
    public int SupportSlotId { get; set; }
    public int? SupportBadgeId { get; set; }

    #endregion

}
