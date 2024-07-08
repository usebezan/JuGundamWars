using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Supports.Appliers;
using Ju.GundamWars.Domain.Supports.Entities;

namespace Ju.GundamWars.Domain.Supports.Factories;

public class SupportSubjectFactory(SupportSubjectApplier applier) : SubjectFactoryBase<Support, SupportSubject, SupportSubjectApplier>(applier)
{

    public SupportSubject CreateForMa() =>
        SubjectApplier.Apply(new Support() { Category = CategoryType.MobileArmor, }, new());

}
