using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Mobiles.Appliers;

namespace Ju.GundamWars.Domain.Mobiles.Factories;

public class MobileFactory(MobileMapper Mapper) : FactoryBase<MobileSubject, Mobile, MobileMapper>(Mapper) { }
