using Ju.GundamWars.Domain.Tags.Model;
using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.Tags.Domain.Service.Mapping;

public class TagModelMapper : TagMapperBase<Tag, TagSubject>
{
    public override TagSubject Map(Tag dto, TagSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
