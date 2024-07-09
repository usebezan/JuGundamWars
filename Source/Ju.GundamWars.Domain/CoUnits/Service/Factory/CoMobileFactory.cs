using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.CoUnits.Dto;
using Ju.GundamWars.Domain.CoUnits.Model;
using Ju.GundamWars.Domain.CoUnits.Service.Mapping;

namespace Ju.GundamWars.Domain.CoUnits.Service.Factory;

public class CoUnitFactory(CoUnitMapper Mapper) : FactoryBase<CoUnitSubject, CoUnit, CoUnitMapper>(Mapper) { }
