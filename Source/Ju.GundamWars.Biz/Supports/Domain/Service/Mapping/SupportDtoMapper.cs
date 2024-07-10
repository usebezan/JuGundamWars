using Ju.GundamWars.Biz.Supports.Domain.Dto;
using Ju.GundamWars.Biz.Supports.Domain.Model;

namespace Ju.GundamWars.Biz.Supports.Domain.Service.Mapping;

public class SupportDtoMapper : SupportMapperBase<Support, SupportDto>
{
    public override SupportDto Map(Support model, SupportDto dto) =>
        Map(model, dto, () =>
        {
            dto.SerialId = model.Serial?.Id ?? 0;
            dto.Grade = model.Grade?.Type ?? 0;

            dto.LimitedSerialMaps.Clear();
            dto.LimitedSerialMaps.AddRange(model.LimitedSerials
                .Select(m => new SupportLimitedSerialMapDto()
                {
                    SupportId = dto.Id,
                    SerialId = m.Id,
                    Support = dto,
                    // TODO: 設定必要？
                    // Serial = ,
                }));

            dto.TagMaps.Clear();
            dto.TagMaps.AddRange(model.Tags
                .Select(m => new SupportTagMapDto()
                {
                    SupportId = dto.Id,
                    TagId = m.Id,
                    Support = dto,
                    // TODO: 設定必要？
                    // Tag = ,
                }));

            byte seq = 1;
            dto.SlotBadges.Clear();
            dto.SlotBadges.AddRange(model.SlotBadges
                .Select(m => new SupportSlotBadgeDto()
                {
                    SupportId = dto.Id,
                    Seq = seq++,
                    SlotId = m.Slot?.Id ?? 0,
                    BadgeId = m.Badge?.Id,
                    Support = dto,
                    // TODO: 設定必要？
                    // Slot = ,
                    // Badge = ,
                }));
        });
}
