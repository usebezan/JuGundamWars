using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Mobiles.Domain.Appliers;
using Ju.GundamWars.Mobiles.Domain.Entities;

namespace Ju.GundamWars.Mobiles.Domain.Factories;

public class MobileFactory(MobileMapper Mapper) : FactoryBase<MobileSubject, Mobile, MobileMapper>(Mapper) { }
