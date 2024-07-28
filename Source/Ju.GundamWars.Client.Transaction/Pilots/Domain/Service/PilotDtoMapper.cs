using Ju.GundamWars.Share.Pilots.Domain;
using Ju.GundamWars.Share.Pilots.Domain.Service;

namespace Ju.GundamWars.Client.Pilots.Domain.Service;

public class PilotDtoMapper : PilotMapperBase<Pilot, PilotStatus, PilotDto, PilotStatusRecord>
{
    public override PilotDto Map(Pilot model, PilotDto dto)
    {
        MapCore(model, dto);
        dto.PilotSlotAbilities.Clear();
        dto.PilotSlotAbilities.AddRange(model.PilotSlotAbilities.Select(m => new PilotSlotAbilityDto() { PilotId = model.Id, Seq = m.Seq, SlotRank = m.SlotRank, PilotAbilityId = m.PilotAbilityId, }));
        dto.TagLinks.Clear();
        dto.TagLinks.AddRange(model.Tags.Select(m => new PilotTagLinkDto() { PilotId = model.Id, TagId = m.Id, }));
        return dto;
    }
}
