using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Cuspas.Domain.Appliers;
using Ju.GundamWars.Cuspas.Domain.Entities;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;

namespace Ju.GundamWars.Cuspas.Domain.Factories;

public class CuspaSubjectFactory(CuspaSubjectMapper Mapper) : SubjectFactoryBase<Cuspa, CuspaSubject, CuspaSubjectMapper>(Mapper)
{

    public CuspaSubject CreateForBs() => SubjectMapper.Map(new Cuspa() { Category = CategoryType.Battleship, }, new());

}
