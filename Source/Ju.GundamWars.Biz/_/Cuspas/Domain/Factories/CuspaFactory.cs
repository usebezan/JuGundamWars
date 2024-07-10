using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Biz._.Cuspas;
using Ju.GundamWars.Biz._.Cuspas.Domain.Entities;
using Ju.GundamWars.Biz._.Cuspas.Domain.Appliers;

namespace Ju.GundamWars.Biz._.Cuspas.Domain.Factories;

public class CuspaFactory(CuspaMapper Mapper) : FactoryBase<CuspaSubject, Cuspa, CuspaMapper>(Mapper) { }
