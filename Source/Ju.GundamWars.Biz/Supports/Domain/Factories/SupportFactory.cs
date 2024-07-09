using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Appliers;
using Ju.GundamWars.Supports.Domain.Entities;

namespace Ju.GundamWars.Supports.Domain.Factories;

public class SupportFactory(SupportMapper Mapper) : FactoryBase<SupportSubject, Support, SupportMapper>(Mapper) { }
