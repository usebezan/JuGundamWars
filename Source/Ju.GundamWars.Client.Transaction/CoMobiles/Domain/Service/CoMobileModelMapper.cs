using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.CoMobiles.Domain.Service;

namespace Ju.GundamWars.Client.CoMobiles.Domain.Service;

public class CoMobileModelMapper(SerialInventory serials, RoleInventory roles, TagInventory tags) : CoMobileMapperBase<CoMobileDto, CoMobileStatusRecord, CoMobileUpgradedCountRecord, CoMobile, CoMobileStatus, CoMobileUpgradedCount>
{
    public override CoMobile Map(CoMobileDto dto, CoMobile model) =>
        model.Initialize(() =>
        {
            model.IsChecked = false;
            MapCore(dto, model);
            model.Tags.ReAddRange(dto.TagLinks.Select(d => tags.FirstOrDefault(i => i.Id == d.TagId)).Where(i => i != null).Select(i => i!));
            model.Serial = serials.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Role = roles.FirstOrDefault(i => i.Type == dto.RoleType);
        });
}
