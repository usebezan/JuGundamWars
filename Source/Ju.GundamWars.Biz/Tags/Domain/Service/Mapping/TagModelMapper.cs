using Ju.GundamWars.Biz.Tags.Domain.Dto;
using Ju.GundamWars.Biz.Tags.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Service.Mapping;

public class TagModelMapper : TagMapperBase<TagDto, Tag>
{
    public override Tag Map(TagDto dto, Tag model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
