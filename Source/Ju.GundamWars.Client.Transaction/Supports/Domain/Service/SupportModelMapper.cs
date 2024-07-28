using Ju.GundamWars.Client.Grades.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Share.Supports.Domain;
using Ju.GundamWars.Share.Supports.Domain.Service;

namespace Ju.GundamWars.Client.Supports.Domain.Service;

public class SupportModelMapper(
    SerialInventory serials,
    GradeInventory grades,
    SupportSlotInventory supportSlots,
    SupportBadgeInventory supportBadges,
    TagInventory tags)
    : SupportMapperBase<SupportDto, Support>
{
    public override Support Map(SupportDto dto, Support model) =>
        model.Initialize(() =>
        {
            model.IsChecked = false;
            MapCore(dto, model);
            model.Serial = serials.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Grade = grades.FirstOrDefault(i => i.Type == dto.GradeType);
            model.SupportLimitedSerials.ReAddRange(dto.SupportLimitedSerialLinks
                .Select(d => serials.FirstOrDefault(i => i.Id == d.SerialId))
                .Where(i => i != null)
                .Select(i => i!));
            model.SupportSlotBadges.ReAddRange(dto.SupportSlotBadges
                .Select(d => new SupportSlotBadge()
                {
                    SupportSlot = supportSlots.FirstOrDefault(i => i.Id == d.SupportSlotId),
                    SupportBadge = supportBadges.FirstOrDefault(i => i.Id == d.SupportBadgeId),
                }));
            model.Tags.ReAddRange(dto.TagLinks.Select(d => tags.FirstOrDefault(i => i.Id == d.TagId)).Where(i => i != null).Select(i => i!));
        });
}
