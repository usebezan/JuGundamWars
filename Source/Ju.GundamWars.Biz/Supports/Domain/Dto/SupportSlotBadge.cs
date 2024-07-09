namespace Ju.GundamWars.Supports.Domain.Entities;

public class SupportSlotBadge
{

    public int SupportId { get; set; }
    public byte Seq { get; set; }
    public int SlotId { get; set; }
    public int? BadgeId { get; set; }

    public Support? Support { get; set; }
    public SupportSlot? Slot { get; set; }
    public SupportBadge? Badge { get; set; }

}
