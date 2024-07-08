using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.CoMobiles.Dto;
using Ju.GundamWars.Domain.CoMobiles.Model;
using Ju.GundamWars.Domain.CoMobiles.Service.Mapping;

namespace Ju.GundamWars.Domain.CoMobiles.Service.Factory;

public class CoMobileFactory(CoMobileApplier applier) : FactoryBase<CoMobileSubject, CoMobile, CoMobileApplier>(applier) { }
