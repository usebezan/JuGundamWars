using Ju.GundamWars.BizTxn.Tags.Domain.Dto;
using Ju.GundamWars.BizTxn.Tags.Domain.Model;

namespace Ju.GundamWars.BizTxn.Tags.Domain.Service.Mapping;

public class TagModelMapper : TagMapperBase<TagDto, Tag>
{
    public override Tag Map(TagDto dto, Tag model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
