using Ju.GundamWars.Domain.Pilots.Appliers;
using Ju.GundamWars.Domain.Pilots.Entities;

namespace Ju.GundamWars.Domain.Pilots.Factories;

public class PilotFactory(PilotApplier applier) : FactoryBase<PilotSubject, Pilot, PilotApplier>(applier) { }
