using Ju.GundamWars.Biz.Tags.Domain.Dto;
using Ju.GundamWars.Biz.Tags.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Service.Mapping;

public class TagDtoMapper : TagMapperBase<TagSubject, TagDto>
{
    public override TagDto Map(TagSubject model, TagDto dto) =>
        Map(model, dto, null!);
}
