using Ju.GundamWars.Domain.CoMobiles.Appliers;
using Ju.GundamWars.Domain.CoMobiles.Entities;

namespace Ju.GundamWars.Domain.CoMobiles.Factories;

public class CoMobileFactory(CoMobileApplier applier) : FactoryBase<CoMobileSubject, CoMobile, CoMobileApplier>(applier) { }
