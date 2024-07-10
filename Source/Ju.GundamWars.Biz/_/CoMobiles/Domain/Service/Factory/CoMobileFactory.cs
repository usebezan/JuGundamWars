using Ju.GundamWars.Biz._.CoMobiles.Domain.Dto;
using Ju.GundamWars.Biz._.CoMobiles.Domain.Model;
using Ju.GundamWars.Biz._.CoMobiles.Domain.Service.Mapping;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.Biz._.CoMobiles.Domain.Service.Factory;

public class CoMobileFactory(CoMobileMapper Mapper) : FactoryBase<CoMobileSubject, CoMobile, CoMobileMapper>(Mapper) { }
