using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Mobiles.Domain.Appliers;
using Ju.GundamWars.Mobiles.Domain.Entities;

namespace Ju.GundamWars.Mobiles.Domain.Factories;

public class MobileSubjectFactory(MobileSubjectMapper Mapper) : SubjectFactoryBase<Mobile, MobileSubject, MobileSubjectMapper>(Mapper)
{

    public MobileSubject CreateForMa() =>
        SubjectMapper.Map(new Mobile() { Category = CategoryType.MobileArmor, }, new());

}
