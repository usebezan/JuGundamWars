using Ju.GundamWars.Domain.Pilots.Entities;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.Domain.Pilots;

public class PilotSkillInventory : GwObservableCollection<PilotSkill>, IPilotSkillInventory { }
