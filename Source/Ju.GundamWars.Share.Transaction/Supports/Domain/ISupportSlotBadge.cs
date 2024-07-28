namespace Ju.GundamWars.Share.Supports.Domain;

public interface ISupportSlotBadge
{

    #region Primitives

    int SupportId { get; set; }
    byte Seq { get; set; }
    int SlotId { get; set; }
    int? BadgeId { get; set; }

    #endregion

}
