namespace Ju.GundamWars.Share.Supports.Domain;

public interface ISupportSlotBadge
{

    #region Primitives

    int SupportId { get; set; }
    byte Seq { get; set; }
    int SupportSlotId { get; set; }
    int? SupportBadgeId { get; set; }

    #endregion

}
