using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Categories;

namespace Ju.GundamWars.Domain.Pilots.Factories;

public class PilotSubjectFactory(PilotSubjectMapper Mapper) : SubjectFactoryBase<Pilot, PilotSubject, PilotSubjectMapper>(Mapper)
{

    public PilotSubject CreateForMa() =>
        SubjectMapper.Map(new Pilot() { Category = CategoryType.MobileArmor, }, new());

}
