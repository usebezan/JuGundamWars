using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories;
using Ju.GundamWars.BizTxn._.Cuspas;
using Ju.GundamWars.BizTxn._.Cuspas.Domain.Entities;
using Ju.GundamWars.BizTxn._.Cuspas.Domain.Appliers;

namespace Ju.GundamWars.BizTxn._.Cuspas.Domain.Factories;

public class CuspaSubjectFactory(CuspaSubjectMapper Mapper) : SubjectFactoryBase<Cuspa, CuspaSubject, CuspaSubjectMapper>(Mapper)
{

    public CuspaSubject CreateForBs() => SubjectMapper.Map(new Cuspa() { Category = CategoryType.Battleship, }, new());

}
