using Ju.GundamWars.BizTxn.Pilots.Domain.Model;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Inventory;

public class PilotInventory : GwNotifiableCollection<PilotSubject>, IPilotInventory { }
