using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.Domain.Cuspas.Appliers;

namespace Ju.GundamWars.Domain.Cuspas.Factories;

public class CuspaFactory(CuspaMapper Mapper) : FactoryBase<CuspaSubject, Cuspa, CuspaMapper>(Mapper) { }
