using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Tags.Dto;
using Ju.GundamWars.Domain.Tags.Model;
using Ju.GundamWars.Domain.Tags.Service.Mapping;

namespace Ju.GundamWars.Domain.Tags.Service.Factory;

public class TagModelFactory(TagModelMapper mapper) : FactoryBase<Tag, TagSubject, TagModelMapper>(mapper)
{
}
