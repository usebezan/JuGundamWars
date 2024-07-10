using Ju.GundamWars.Biz._.Mobiles.Domain;
using Ju.GundamWars.Biz._.Mobiles.Domain.Appliers;
using Ju.GundamWars.Biz._.Mobiles.Domain.Entities;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Factories;

public class MobileSubjectFactory(MobileSubjectMapper Mapper) : SubjectFactoryBase<Mobile, MobileSubject, MobileSubjectMapper>(Mapper)
{

    public MobileSubject CreateForMa() =>
        SubjectMapper.Map(new Mobile() { Category = CategoryType.MobileArmor, }, new());

}
