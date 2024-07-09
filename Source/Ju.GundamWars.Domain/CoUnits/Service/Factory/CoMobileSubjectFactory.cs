using Ju.GundamWars.Domain.Categories;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.CoUnits.Dto;
using Ju.GundamWars.Domain.CoUnits.Model;
using Ju.GundamWars.Domain.CoUnits.Service.Mapping;
using Ju.GundamWars.Domain.Roles;

namespace Ju.GundamWars.Domain.CoUnits.Service.Factory;

public class CoUnitSubjectFactory(CoUnitSubjectMapper subjectMapper)
    : SubjectFactoryBase<CoUnit, CoUnitSubject, CoUnitSubjectMapper>(subjectMapper), IFactory<CoUnitSubject>
{

    public CoUnitSubject CreateForMa() =>
        SubjectMapper.Map(new CoUnit() { Category = CategoryType.MobileArmor, Role = RoleType.Defender, }, new());

}
