using Ju.GundamWars.Domain.Skills.Dto;
using Ju.GundamWars.Domain.Skills.Model;

namespace Ju.GundamWars.Domain.Skills.Service.Mapping;

public class SkillModelMapper : SkillMapperBase<Skill, SkillSubject>
{
    public override SkillSubject Map(Skill dto, SkillSubject model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;
        });
}
