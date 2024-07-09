using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.Domain.Pilots.Appliers;

namespace Ju.GundamWars.Domain.Pilots.Factories;

public class PilotFactory(PilotMapper Mapper) : FactoryBase<PilotSubject, Pilot, PilotMapper>(Mapper) { }
