using Ju.GundamWars.Biz.Pilots.Domain.Entities;
using Ju.GundamWars.UseCase.Pilots;

namespace Ju.GundamWars.Biz.Pilots.Domain;

public class PilotSkillInventory : GwObservableCollection<PilotSkill>, IPilotSkillInventory { }
