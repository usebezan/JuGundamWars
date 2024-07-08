using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Domain.Tags.Factories;

public class TagFactory : IFactory<TagSubject, Tag>
{

    public Tag Create(TagSubject src) =>
        new()
        {
            Id = src.Id,
            Kind = src.KindType,
            Name = src.Name,
            Order = src.Order,
        };

}
