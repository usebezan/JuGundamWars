using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;
using Ju.GundamWars.BizTxn.Pilots.Domain.Model;
using Ju.GundamWars.BizTxn.Tags.Domain.Inventory;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Service.Mapping;

public class PilotModelMapper(
    SerialInventory serialInventory,
    GradeInventory gradeInventory,
    TagInventory tagInventory,
    SkillInventory skillInventory,
    PilotAbilityInventory pilotAbilityInventory) : PilotMapperBase<PilotDto, Pilot>
{
    public override Pilot Map(PilotDto dto, Pilot model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;

            model.BasicStatus.Shooting = dto.Shooting;
            model.BasicStatus.Melee = dto.Melee;
            model.BasicStatus.Accuracy = dto.Accuracy;
            model.BasicStatus.Evasion = dto.Evasion;
            model.BasicStatus.Awakened = dto.Awakened;
            model.BasicStatus.Defense = dto.Defense;

            model.PracticedStatus.Shooting = dto.PracticedShooting;
            model.PracticedStatus.Melee = dto.PracticedMelee;
            model.PracticedStatus.Accuracy = dto.PracticedAccuracy;
            model.PracticedStatus.Evasion = dto.PracticedEvasion;
            model.PracticedStatus.Awakened = dto.PracticedAwakened;
            model.PracticedStatus.Defense = dto.PracticedDefense;

            model.Serial = serialInventory.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Grade = gradeInventory.FirstOrDefault(i => i.Type == dto.Grade);
            model.Skill = skillInventory.FirstOrDefault(i => i.Id == dto.SkillId);
            model.Ability1 = pilotAbilityInventory.FirstOrDefault(i => i.Id == dto.AbilityId1);
            model.Ability2 = pilotAbilityInventory.FirstOrDefault(i => i.Id == dto.AbilityId2);
            model.Ability3 = pilotAbilityInventory.FirstOrDefault(i => i.Id == dto.AbilityId3);

            model.Tags.ReAddRange(dto.TagMaps
                .Select(d => tagInventory.FirstOrDefault(i => i.Id == d.TagId))
                .Where(i => i != null)
                .Select(i => i!));
        });
}
