using Ju.GundamWars.Biz.Supports.Domain.Dto;
using Ju.GundamWars.Biz.Supports.Domain.Model;
using Ju.GundamWars.Biz.Tags.Domain.Inventory;
using Ju.GundamWars.BizMaster.Grades.Domain.Inventory;
using Ju.GundamWars.BizMaster.Serials.Domain.Inventory;
using Ju.GundamWars.BizMaster.SupportBadges.Domain.Inventory;
using Ju.GundamWars.BizMaster.SupportSlots.Domain.Inventory;

namespace Ju.GundamWars.Biz.Supports.Domain.Service.Mapping;

public class SupportModelMapper(
    SerialInventory serialInventory,
    GradeInventory gradeInventory,
    TagInventory tagInventory,
    SupportSlotInventory supportSlotInventory,
    SupportBadgeInventory supportBadgeInventory)
        : SupportMapperBase<SupportDto, SupportSubject>
{
    public override SupportSubject Map(SupportDto dto, SupportSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;

            model.Serial = serialInventory.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Grade = gradeInventory.FirstOrDefault(i => i.Type == dto.Grade);

            model.LimitedSerials.ReAddRange(dto.LimitedSerialMaps
                .Select(d => serialInventory.FirstOrDefault(i => i.Id == d.SerialId))
                .Where(i => i != null));

            model.Tags.ReAddRange(dto.TagMaps
                .Select(d => tagInventory.FirstOrDefault(i => i.Id == d.TagId))
                .Where(i => i != null));

            model.SlotBadges.ReAddRange(dto.SlotBadges
                .Select(d => new SupportSlotBadgeSubject()
                {
                    Slot = supportSlotInventory.FirstOrDefault(i => i.Id == d.SlotId),
                    Badge = supportBadgeInventory.FirstOrDefault(i => i.Id == d.BadgeId),
                }));
        });
}
