using Ju.GundamWars.Biz.Supports.Domain.Dto;
using Ju.GundamWars.Biz.Supports.Domain.Model;

namespace Ju.GundamWars.Biz.Supports.Domain.Service.Mapping;

public class SupportDtoMapper : SupportMapperBase<SupportSubject, SupportDto>
{
    public override SupportDto Map(SupportSubject model, SupportDto dto) =>
        Map(model, dto, null!);
}
