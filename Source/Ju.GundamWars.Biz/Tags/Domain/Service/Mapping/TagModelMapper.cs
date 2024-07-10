using Ju.GundamWars.Biz.Tags.Domain.Dto;
using Ju.GundamWars.Biz.Tags.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Service.Mapping;

public class TagModelMapper : TagMapperBase<TagDto, TagSubject>
{
    public override TagSubject Map(TagDto dto, TagSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
