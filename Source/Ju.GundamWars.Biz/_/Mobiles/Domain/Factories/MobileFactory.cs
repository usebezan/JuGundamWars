using Ju.GundamWars.Biz._.Mobiles.Domain;
using Ju.GundamWars.Biz._.Mobiles.Domain.Appliers;
using Ju.GundamWars.Biz._.Mobiles.Domain.Entities;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Factories;

public class MobileFactory(MobileMapper Mapper) : FactoryBase<MobileSubject, Mobile, MobileMapper>(Mapper) { }
