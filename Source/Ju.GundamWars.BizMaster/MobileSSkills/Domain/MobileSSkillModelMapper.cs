using Ju.GundamWars.BizMaster.Skills.Domain;

namespace Ju.GundamWars.BizMaster.MobileSSkills.Domain;

public class MobileSSkillModelMapper(SkillInventory skillInventory) : MobileSSkillPrimitiveMapper<MobileSSkillDto, MobileSSkill>
{
    public new MobileSSkill Map(MobileSSkillDto src, MobileSSkill dest)
    {
        base.Map(src, dest);
        dest.Skill = skillInventory.FirstOrDefault(m => m.Id == src.SkillId);
        return dest;
    }
}
