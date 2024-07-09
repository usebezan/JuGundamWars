using Ju.GundamWars.Common.Domain.Service.Mapping;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Entities;

namespace Ju.GundamWars.Supports.Domain.Appliers;

public class SupportMapper : IMapper<SupportSubject, Support>
{

    public Support Map(SupportSubject subject, Support entity)
    {
        entity.Id = subject.Id;
        entity.Name = subject.Name;
        entity.Category = subject.Category?.Type ?? 0;
        entity.SerialId = subject.Serial?.Id ?? 0;
        entity.Grade = subject.Grade?.Type ?? 0;
        entity.Memo = subject.Memo;
        entity.IsPinned = subject.IsPinned;

        entity.LimitedSerialMaps.Clear();
        entity.LimitedSerialMaps.AddRange(subject.LimitedSerials.Select(s => new SupportLimitedSerialMap()
        {
            SupportId = entity.Id,
            SerialId = s.Id,
            Support = entity,
        }));

        entity.TagMaps.Clear();
        entity.TagMaps.AddRange(subject.Tags.Select(s => new SupportTagMap()
        {
            SupportId = entity.Id,
            TagId = s.Id,
            Support = entity,
        }));

        byte seq = 1;
        entity.SlotBadges.Clear();
        entity.SlotBadges.AddRange(subject.SlotBadges.Select(s => new SupportSlotBadge()
        {
            SupportId = entity.Id,
            Seq = seq++,
            SlotId = s.Slot?.Id ?? 0,
            BadgeId = s.Badge?.Id,
            Support = entity,
        }));

        return entity;
    }

}
