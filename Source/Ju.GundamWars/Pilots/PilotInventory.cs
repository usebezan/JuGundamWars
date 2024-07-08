using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.Pilots;

public class PilotInventory : GwNotifiableCollection<PilotSubject>, IPilotInventory { }
