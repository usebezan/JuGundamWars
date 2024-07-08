using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoMobiles.Appliers;
using Ju.GundamWars.Domain.CoMobiles.Entities;

namespace Ju.GundamWars.Domain.CoMobiles.Factories;

public class CoMobileSubjectFactory(CoMobileSubjectApplier subjectApplier)
    : SubjectFactoryBase<CoMobile, CoMobileSubject, CoMobileSubjectApplier>(subjectApplier), IFactory<CoMobileSubject>
{

    public CoMobileSubject CreateForMa() =>
        SubjectApplier.Apply(new CoMobile() { Category = CategoryType.MobileArmor, Role = RoleType.Defender, }, new());

}
