using Ju.GundamWars.Client.Skills.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain;
using Ju.GundamWars.Share.PilotSkills.Domain.Service;

namespace Ju.GundamWars.Client.PilotSkills.Domain.Service;

public class PilotSkillModelMapper(SkillInventory skills) : PilotSkillMapper<PilotSkillDto, PilotSkill>
{
    public new PilotSkill Map(PilotSkillDto dto, PilotSkill model)
    {
        base.Map(dto, model);
        model.Skill = skills.FirstOrDefault(m => m.Id == dto.SkillId);
        return model;
    }
}
