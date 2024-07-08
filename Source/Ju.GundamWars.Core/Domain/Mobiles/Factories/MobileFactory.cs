using Ju.GundamWars.Domain.Mobiles.Appliers;
using Ju.GundamWars.Domain.Mobiles.Entities;

namespace Ju.GundamWars.Domain.Mobiles.Factories;

public class MobileFactory(MobileApplier applier) : FactoryBase<MobileSubject, Mobile, MobileApplier>(applier) { }
