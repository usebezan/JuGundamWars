using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Pilots.Entities;

namespace Ju.GundamWars.Domain.Pilots.Factories;

public class PilotSubjectFactory(PilotSubjectApplier applier) : SubjectFactoryBase<Pilot, PilotSubject, PilotSubjectApplier>(applier)
{

    public PilotSubject CreateForMa() =>
        SubjectApplier.Apply(new Pilot() { Category = CategoryType.MobileArmor, }, new());

}
