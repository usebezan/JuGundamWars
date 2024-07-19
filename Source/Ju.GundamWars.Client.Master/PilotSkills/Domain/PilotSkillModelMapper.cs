using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain;

namespace Ju.GundamWars.Client.PilotSkills.Domain;

public class PilotSkillModelMapper(SkillInventory skillInventory) : PilotSkillPrimitiveMapper<PilotSkillDto, PilotSkill>
{
    public new PilotSkill Map(PilotSkillDto src, PilotSkill dest)
    {
        base.Map(src, dest);
        dest.Skill = skillInventory.FirstOrDefault(m => m.Id == src.SkillId);
        return dest;
    }
}
