using Ju.GundamWars.Domain.Tags.Dto;
using Ju.GundamWars.Domain.Tags.Model;

namespace Ju.GundamWars.Domain.Tags.Service.Mapping;

public class TagModelMapper : TagMapperBase<Tag, TagSubject>
{
    public override TagSubject Map(Tag dto, TagSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
