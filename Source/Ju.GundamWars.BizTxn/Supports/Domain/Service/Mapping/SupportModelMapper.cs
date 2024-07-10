using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizTxn.Supports.Domain.Dto;
using Ju.GundamWars.BizTxn.Supports.Domain.Model;
using Ju.GundamWars.BizTxn.Tags.Domain.Inventory;

namespace Ju.GundamWars.BizTxn.Supports.Domain.Service.Mapping;

public class SupportModelMapper(
    SerialInventory serialInventory,
    GradeInventory gradeInventory,
    TagInventory tagInventory,
    SupportSlotInventory supportSlotInventory,
    SupportBadgeInventory supportBadgeInventory)
        : SupportMapperBase<SupportDto, Support>
{
    public override Support Map(SupportDto dto, Support model) =>
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
                .Select(d => new SupportSlotBadge()
                {
                    Slot = supportSlotInventory.FirstOrDefault(i => i.Id == d.SlotId),
                    Badge = supportBadgeInventory.FirstOrDefault(i => i.Id == d.BadgeId),
                }));
        });
}
