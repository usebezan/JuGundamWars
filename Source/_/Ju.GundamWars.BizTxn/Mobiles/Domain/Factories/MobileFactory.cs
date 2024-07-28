using Ju.GundamWars.BizTxn._.Mobiles.Domain;
using Ju.GundamWars.BizTxn._.Mobiles.Domain.Appliers;
using Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain.Factories;

public class MobileFactory(MobileMapper Mapper) : FactoryBase<MobileSubject, Mobile, MobileMapper>(Mapper) { }
