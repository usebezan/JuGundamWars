using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;

namespace Ju.GundamWars.Client.CoMobiles.Domain.Service;

public class CoMobileDtoMapper : CoMobileMapperBase<CoMobile, CoMobileStatus, CoMobileUpgradedCount, CoMobileDto, CoMobileStatusRecord, CoMobileUpgradedCountRecord>
{
    public override CoMobileDto Map(CoMobile model, CoMobileDto dto)
    {
        MapCore(model, dto);
        dto.TagLinks.Clear();
        dto.TagLinks.AddRange(model.Tags.Select(m => new CoMobileTagLinkDto() { CoMobileId = model.Id, TagId = m.Id, }));
        return dto;
    }
}
