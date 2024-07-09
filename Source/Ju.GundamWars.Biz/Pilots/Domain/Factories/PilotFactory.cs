using Ju.GundamWars.Domain.Common.Service.Factory;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Appliers;
using Ju.GundamWars.Pilots.Domain.Entities;

namespace Ju.GundamWars.Pilots.Domain.Factories;

public class PilotFactory(PilotMapper Mapper) : FactoryBase<PilotSubject, Pilot, PilotMapper>(Mapper) { }
