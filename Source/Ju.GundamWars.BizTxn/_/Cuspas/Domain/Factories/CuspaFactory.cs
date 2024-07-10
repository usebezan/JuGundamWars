using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.BizTxn._.Cuspas;
using Ju.GundamWars.BizTxn._.Cuspas.Domain.Entities;
using Ju.GundamWars.BizTxn._.Cuspas.Domain.Appliers;

namespace Ju.GundamWars.BizTxn._.Cuspas.Domain.Factories;

public class CuspaFactory(CuspaMapper Mapper) : FactoryBase<CuspaSubject, Cuspa, CuspaMapper>(Mapper) { }
