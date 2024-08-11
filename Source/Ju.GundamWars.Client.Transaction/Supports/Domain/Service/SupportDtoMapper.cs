using Ju.GundamWars.Share.Supports.Domain;
using Ju.GundamWars.Share.Supports.Domain.Service;

namespace Ju.GundamWars.Client.Supports.Domain.Service;

public class SupportDtoMapper : SupportMapperBase<Support, SupportDto>
{
    public override SupportDto Map(Support model, SupportDto dto)
    {
        MapCore(model, dto);
        dto.SupportLimitedSerialLinks.Clear();
        dto.SupportLimitedSerialLinks.AddRange(model.SupportLimitedSerials.Select(m => new SupportLimitedSerialLinkDto() { SupportId = model.Id, SerialId = m.Id, }));
        dto.SupportSlotBadges.Clear();
        dto.SupportSlotBadges.AddRange(model.SupportSlotBadges.Select(m => new SupportSlotBadgeDto() { SupportId = model.Id, Seq = m.Seq, SupportSlotId = m.SupportSlotId, SupportBadgeId = m.SupportBadgeId, }));
        dto.TagLinks.Clear();
        dto.TagLinks.AddRange(model.Tags.Select(m => new SupportTagLinkDto() { SupportId = model.Id, TagId = m.Id, }));
        return dto;
    }
}
