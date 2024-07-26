using Ju.GundamWars.Share.Cuspas.Domain;
using Ju.GundamWars.Share.Cuspas.Domain.Service;

namespace Ju.GundamWars.Client.Cuspas.Domain.Service;

public class CuspaDtoMapper : CuspaMapperBase<Cuspa, CuspaStatus, CuspaDto, CuspaStatusRecord>
{
    public override CuspaDto Map(Cuspa model, CuspaDto dto)
    {
        MapCore(model, dto);
        dto.TagLinks.Clear();
        dto.TagLinks.AddRange(model.Tags.Select(m => new CuspaTagLinkDto() { CuspaId = dto.Id, TagId = m.Id, }));
        return dto;
    }
}
