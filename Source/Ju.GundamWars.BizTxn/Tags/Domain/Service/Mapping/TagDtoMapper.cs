using Ju.GundamWars.BizTxn.Tags.Domain.Dto;
using Ju.GundamWars.BizTxn.Tags.Domain.Model;

namespace Ju.GundamWars.BizTxn.Tags.Domain.Service.Mapping;

public class TagDtoMapper : TagMapperBase<Tag, TagDto>
{
    public override TagDto Map(Tag model, TagDto dto) =>
        Map(model, dto, null!);
}
