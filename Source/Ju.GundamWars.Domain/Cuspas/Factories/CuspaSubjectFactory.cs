using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Cuspas.Appliers;
using Ju.GundamWars.Domain.Cuspas.Entities;

namespace Ju.GundamWars.Domain.Cuspas.Factories;

public class CuspaSubjectFactory(CuspaSubjectApplier applier) : SubjectFactoryBase<Cuspa, CuspaSubject, CuspaSubjectApplier>(applier)
{

    public CuspaSubject CreateForBs() => SubjectApplier.Apply(new Cuspa() { Category = CategoryType.Battleship, }, new());

}
