using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Tags.Appliers;
using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Domain.Tags.Factories;

public class TagSubjectFactory(TagSubjectApplier applier) : FactoryBase<Tag, TagSubject, TagSubjectApplier>(applier) { }
