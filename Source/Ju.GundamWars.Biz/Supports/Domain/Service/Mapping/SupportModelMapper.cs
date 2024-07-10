using Ju.GundamWars.Biz.Supports.Domain.Dto;
using Ju.GundamWars.Biz.Supports.Domain.Model;

namespace Ju.GundamWars.Biz.Supports.Domain.Service.Mapping;

public class SupportModelMapper : SupportMapperBase<SupportDto, SupportSubject>
{
    public override SupportSubject Map(SupportDto dto, SupportSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
