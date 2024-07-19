using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Share.MobileSSkills.Domain;

namespace Ju.GundamWars.Client.MobileSSkills.Domain;

public class MobileSSkillModelMapper(SkillInventory skillInventory) : MobileSSkillPrimitiveMapper<MobileSSkillDto, MobileSSkill>
{
    public new MobileSSkill Map(MobileSSkillDto src, MobileSSkill dest)
    {
        base.Map(src, dest);
        dest.Skill = skillInventory.FirstOrDefault(m => m.Id == src.SkillId);
        return dest;
    }
}
