using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.Pilots.Domain;

public class PilotAbilityInventory : GwObservableCollection<PilotAbility>, IPilotAbilityInventory { }
