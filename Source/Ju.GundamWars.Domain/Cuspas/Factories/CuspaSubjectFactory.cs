using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Cuspas.Appliers;
using Ju.GundamWars.Domain.Categories;

namespace Ju.GundamWars.Domain.Cuspas.Factories;

public class CuspaSubjectFactory(CuspaSubjectMapper Mapper) : SubjectFactoryBase<Cuspa, CuspaSubject, CuspaSubjectMapper>(Mapper)
{

    public CuspaSubject CreateForBs() => SubjectMapper.Map(new Cuspa() { Category = CategoryType.Battleship, }, new());

}
