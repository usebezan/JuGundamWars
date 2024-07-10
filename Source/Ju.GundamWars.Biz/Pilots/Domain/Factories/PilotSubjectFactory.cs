using Ju.GundamWars.Biz.Pilots.Domain;
using Ju.GundamWars.Biz.Pilots.Domain.Appliers;
using Ju.GundamWars.Biz.Pilots.Domain.Entities;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.Biz.Pilots.Domain.Factories;

public class PilotSubjectFactory(PilotSubjectMapper Mapper) : SubjectFactoryBase<Pilot, PilotSubject, PilotSubjectMapper>(Mapper)
{

    public PilotSubject CreateForMa() =>
        SubjectMapper.Map(new Pilot() { Category = CategoryType.MobileArmor, }, new());

}
