using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Dto;
using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Model;
using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Service.Mapping;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.BizTxn._.CoMobiles.Domain.Service.Factory;

public class CoMobileFactory(CoMobileMapper Mapper) : FactoryBase<CoMobileSubject, CoMobile, CoMobileMapper>(Mapper) { }
