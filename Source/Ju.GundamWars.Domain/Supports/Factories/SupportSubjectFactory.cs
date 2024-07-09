using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Supports.Appliers;
using Ju.GundamWars.Domain.Categories;

namespace Ju.GundamWars.Domain.Supports.Factories;

public class SupportSubjectFactory(SupportSubjectMapper Mapper) : SubjectFactoryBase<Support, SupportSubject, SupportSubjectMapper>(Mapper)
{

    public SupportSubject CreateForMa() =>
        SubjectMapper.Map(new Support() { Category = CategoryType.MobileArmor, }, new());

}
