using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Mobiles.Entities;

namespace Ju.GundamWars.Domain.Mobiles.Factories;

public class MobileSubjectFactory(MobileSubjectApplier applier) : SubjectFactoryBase<Mobile, MobileSubject, MobileSubjectApplier>(applier)
{

    public MobileSubject CreateForMa() =>
        SubjectApplier.Apply(new Mobile() { Category = CategoryType.MobileArmor, }, new());

}
