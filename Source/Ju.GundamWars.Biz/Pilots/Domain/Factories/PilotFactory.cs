using Ju.GundamWars.Biz.Pilots.Domain.Appliers;
using Ju.GundamWars.Biz.Pilots.Domain.Entities;
using Ju.GundamWars.Domain.Common.Service.Factory;

namespace Ju.GundamWars.Biz.Pilots.Domain.Factories;

public class PilotFactory(PilotMapper Mapper) : FactoryBase<PilotSubject, Pilot, PilotMapper>(Mapper) { }
