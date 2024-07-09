using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Cuspas.Domain.Appliers;
using Ju.GundamWars.Cuspas.Domain.Entities;
using Ju.GundamWars.Core.Ju.GundamWars.Cuspas;

namespace Ju.GundamWars.Cuspas.Domain.Factories;

public class CuspaFactory(CuspaMapper Mapper) : FactoryBase<CuspaSubject, Cuspa, CuspaMapper>(Mapper) { }
