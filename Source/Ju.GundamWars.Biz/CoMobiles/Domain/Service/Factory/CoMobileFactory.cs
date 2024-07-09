using Ju.GundamWars.Core.CoMobiles.Domain.Dto;
using Ju.GundamWars.Core.CoMobiles.Domain.Model;
using Ju.GundamWars.Core.CoMobiles.Domain.Service.Mapping;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.Core.CoMobiles.Domain.Service.Factory;

public class CoMobileFactory(CoMobileMapper Mapper) : FactoryBase<CoMobileSubject, CoMobile, CoMobileMapper>(Mapper) { }
