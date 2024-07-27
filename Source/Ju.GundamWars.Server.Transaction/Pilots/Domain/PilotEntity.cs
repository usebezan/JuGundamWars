using Ju.GundamWars.Share.Pilots.Domain;

namespace Ju.GundamWars.Server.Pilots.Domain;

public record PilotEntity : PilotBase<PilotSlotAbilityEntity, PilotTagLinkEntity>
{
}
