namespace Ju.GundamWars.Share.Pilots.Domain;

public record PilotSlotAbilityBase : IPilotSlotAbility
{

    #region Primitives

    public int PilotId { get; set; }
    public byte Seq { get; set; }
    public byte SlotRank { get; set; }
    public int? PilotAbilityId { get; set; }

    #endregion

}
