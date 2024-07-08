using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.Domain.Supports.Appliers;

public class SupportSubjectApplier(
    ICategoryInventory categoryInventory,
    ISerialInventory serialInventory,
    IGradeInventory gradeInventory,
    ITagInventory tagInventory,
    ISupportSlotInventory supportSlotInventory,
    ISupportBadgeInventory supportBadgeInventory)
    : IApplier<Support, SupportSubject>
{

    public SupportSubject Apply(Support entity, SupportSubject subject)
    {
        subject.Initialize(() =>
        {
            subject.Id = entity.Id;
            subject.Name = entity.Name;
            subject.Memo = entity.Memo;
            subject.IsPinned = entity.IsPinned;

            subject.Category = categoryInventory.FirstOrDefault(i => i.Type == entity.Category);
            subject.Serial = serialInventory.FirstOrDefault(i => i.Id == entity.SerialId);
            subject.Grade = gradeInventory.FirstOrDefault(i => i.Type == entity.Grade);

            subject.LimitedSerials.Clear();
            entity.LimitedSerialMaps.ForEach(m =>
            {
                var serial = serialInventory.FirstOrDefault(i => i.Id == m.SerialId);
                if (serial != null)
                {
                    subject.LimitedSerials.Add(serial);
                }
            });

            subject.Tags.Clear();
            entity.TagMaps.ForEach(m =>
            {
                var tag = tagInventory.FirstOrDefault(i => i.Id == m.TagId);
                if (tag != null)
                {
                    subject.Tags.Add(tag);
                }
            });

            subject.SlotBadges.Clear();
            entity.SlotBadges.ForEach(m =>
            {
                subject.SlotBadges.Add(new()
                {
                    Support = subject,
                    Slot = supportSlotInventory.FirstOrDefault(i => i.Id == m.SlotId),
                    Badge = supportBadgeInventory.FirstOrDefault(i => i.Id == m.BadgeId),
                });
            });
        });
        return subject;
    }

}
