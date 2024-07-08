using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.CoMobiles.Dto;
using Ju.GundamWars.Domain.CoMobiles.Model;
using Ju.GundamWars.Domain.CoMobiles.Service.Mapping;

namespace Ju.GundamWars.Domain.CoMobiles.Service.Factory;

public class CoMobileSubjectFactory(CoMobileSubjectApplier subjectApplier)
    : SubjectFactoryBase<CoMobile, CoMobileSubject, CoMobileSubjectApplier>(subjectApplier), IFactory<CoMobileSubject>
{

    public CoMobileSubject CreateForMa() =>
        SubjectApplier.Apply(new CoMobile() { Category = CategoryType.MobileArmor, Role = RoleType.Defender, }, new());

}
