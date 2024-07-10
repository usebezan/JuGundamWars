using Ju.GundamWars.Biz.Pilots.Domain.Entities;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.Biz.Pilots.Domain;

public class PilotAbilityInventory : GwObservableCollection<PilotAbility>, IPilotAbilityInventory { }
