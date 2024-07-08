using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Cuspas.Appliers;
using Ju.GundamWars.Domain.Cuspas.Entities;

namespace Ju.GundamWars.Domain.Cuspas.Factories;

public class CuspaFactory(CuspaApplier applier) : FactoryBase<CuspaSubject, Cuspa, CuspaApplier>(applier) { }
