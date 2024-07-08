using Ju.GundamWars.Domain.Common.Service.Mapping;
using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Domain.Tags.Appliers;

public class TagSubjectApplier : IApplier<Tag, TagSubject>
{

    public TagSubject Apply(Tag entity, TagSubject subject)
    {
        subject.IsChecked = false;
        subject.Id = entity.Id;
        subject.KindType = entity.Kind;
        subject.Name = entity.Name;
        subject.Order = entity.Order;
        return subject;
    }

}
