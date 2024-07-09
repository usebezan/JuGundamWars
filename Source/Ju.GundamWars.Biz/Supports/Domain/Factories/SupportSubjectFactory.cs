using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Appliers;
using Ju.GundamWars.Supports.Domain.Entities;

namespace Ju.GundamWars.Supports.Domain.Factories;

public class SupportSubjectFactory(SupportSubjectMapper Mapper) : SubjectFactoryBase<Support, SupportSubject, SupportSubjectMapper>(Mapper)
{

    public SupportSubject CreateForMa() =>
        SubjectMapper.Map(new Support() { Category = CategoryType.MobileArmor, }, new());

}
