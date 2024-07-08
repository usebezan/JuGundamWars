using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Supports.Appliers;
using Ju.GundamWars.Domain.Supports.Entities;

namespace Ju.GundamWars.Domain.Supports.Factories;

public class SupportFactory(SupportApplier applier) : FactoryBase<SupportSubject, Support, SupportApplier>(applier) { }
