using Ju.GundamWars.Biz.Tags.Domain.Dto;
using Ju.GundamWars.Biz.Tags.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Service.Mapping;

public class TagDtoMapper : TagMapperBase<TagSubject, Tag>
{
    public override Tag Map(TagSubject model, Tag dto) =>
        Map(model, dto, null!);
}
