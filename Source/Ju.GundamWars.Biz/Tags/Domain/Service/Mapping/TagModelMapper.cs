using Ju.GundamWars.Biz.Tags.Domain.Dto;
using Ju.GundamWars.Biz.Tags.Domain.Model;

namespace Ju.GundamWars.Biz.Tags.Domain.Service.Mapping;

public class TagModelMapper : TagMapperBase<Tag, TagSubject>
{
    public override TagSubject Map(Tag dto, TagSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
