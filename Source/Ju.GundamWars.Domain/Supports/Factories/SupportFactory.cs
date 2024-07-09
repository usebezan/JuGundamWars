using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Supports.Appliers;

namespace Ju.GundamWars.Domain.Supports.Factories;

public class SupportFactory(SupportMapper Mapper) : FactoryBase<SupportSubject, Support, SupportMapper>(Mapper) { }
