using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Categories;

namespace Ju.GundamWars.Domain.Mobiles.Factories;

public class MobileSubjectFactory(MobileSubjectMapper Mapper) : SubjectFactoryBase<Mobile, MobileSubject, MobileSubjectMapper>(Mapper)
{

    public MobileSubject CreateForMa() =>
        SubjectMapper.Map(new Mobile() { Category = CategoryType.MobileArmor, }, new());

}
