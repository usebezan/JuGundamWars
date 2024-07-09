using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Appliers;
using Ju.GundamWars.Pilots.Domain.Entities;

namespace Ju.GundamWars.Pilots.Domain.Factories;

public class PilotSubjectFactory(PilotSubjectMapper Mapper) : SubjectFactoryBase<Pilot, PilotSubject, PilotSubjectMapper>(Mapper)
{

    public PilotSubject CreateForMa() =>
        SubjectMapper.Map(new Pilot() { Category = CategoryType.MobileArmor, }, new());

}
