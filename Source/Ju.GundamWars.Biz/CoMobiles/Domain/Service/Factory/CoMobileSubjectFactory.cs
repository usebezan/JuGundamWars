using Ju.GundamWars.Common.Domain.Service.Factory;
using Ju.GundamWars.Core.CoMobiles.Domain.Dto;
using Ju.GundamWars.Core.CoMobiles.Domain.Model;
using Ju.GundamWars.Core.CoMobiles.Domain.Service.Mapping;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Roles;

namespace Ju.GundamWars.Core.CoMobiles.Domain.Service.Factory;

public class CoMobileSubjectFactory(CoMobileSubjectMapper subjectMapper)
    : SubjectFactoryBase<CoMobile, CoMobileSubject, CoMobileSubjectMapper>(subjectMapper), IFactory<CoMobileSubject>
{

    public CoMobileSubject CreateForMa() =>
        SubjectMapper.Map(new CoMobile() { Category = CategoryType.MobileArmor, Role = RoleType.Defender, }, new());

}
