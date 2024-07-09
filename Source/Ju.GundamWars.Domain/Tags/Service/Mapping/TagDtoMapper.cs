using Ju.GundamWars.Domain.Tags.Dto;
using Ju.GundamWars.Domain.Tags.Model;

namespace Ju.GundamWars.Domain.Tags.Service.Mapping;

public class TagDtoMapper : TagMapperBase<TagSubject, Tag>
{
    public override Tag Map(TagSubject model, Tag dto) =>
        Map(model, dto, null!);
}
