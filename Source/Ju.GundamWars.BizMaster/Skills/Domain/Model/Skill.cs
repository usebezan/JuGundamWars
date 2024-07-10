using Ju.GundamWars.BizMaster.SkillGroups.Domain;

namespace Ju.GundamWars.BizMaster.Skills.Domain.Model;

public record Skill(int Id, SkillGroupType Group, string Name, int Order)
{
}
