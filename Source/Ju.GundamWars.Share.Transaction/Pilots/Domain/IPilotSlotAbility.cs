namespace Ju.GundamWars.Share.Pilots.Domain;

public interface IPilotSlotAbility
{

    #region Primitives

    int PilotId { get; set; }
    byte Seq { get; set; }
    byte SlotRank { get; set; }
    int? PilotAbilityId { get; set; }

    #endregion

}
