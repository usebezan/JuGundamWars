using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Share.Cuspas.Domain;
using Ju.GundamWars.Share.Cuspas.Domain.Service;

namespace Ju.GundamWars.Client.Cuspas.Domain.Service;

public class CuspaModelMapper(CuspaKindInventory cuspaKinds, BoostStatusInventory boostStatuses, TagInventory tags) : CuspaMapperBase<CuspaDto, CuspaStatusRecord, Cuspa, CuspaStatus>
{
    public override Cuspa Map(CuspaDto dto, Cuspa model) =>
        model.Initialize(() =>
        {
            model.IsChecked = false;
            MapCore(dto, model);
            model.CuspaKind = cuspaKinds.FirstOrDefault(i => i.Type == dto.CuspaKindType);
            model.BoostStatus = boostStatuses.FirstOrDefault(i => i.Type == dto.BoostStatusType);
            model.Tags.ReAddRange(dto.TagLinks.Select(d => tags.FirstOrDefault(i => i.Id == d.TagId)).Where(i => i != null).Select(i => i!));
        });
}
