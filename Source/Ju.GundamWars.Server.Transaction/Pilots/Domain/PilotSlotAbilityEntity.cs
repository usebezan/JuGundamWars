using Ju.GundamWars.Share.Pilots.Domain;

namespace Ju.GundamWars.Server.Pilots.Domain;

public record PilotSlotAbilityEntity : PilotSlotAbilityBase
{

    #region Navigations

    public PilotEntity? Pilot { get; set; }

    #endregion

}
