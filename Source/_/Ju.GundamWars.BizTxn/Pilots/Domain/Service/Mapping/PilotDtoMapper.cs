using Ju.GundamWars.BizTxn.Pilots.Domain.Dto;
using Ju.GundamWars.BizTxn.Pilots.Domain.Model;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Service.Mapping;

public class PilotDtoMapper : PilotMapperBase<Pilot, PilotDto>
{
    public override PilotDto Map(Pilot model, PilotDto dto) =>
        Map(model, dto, () =>
        {
            dto.SerialId = model.Serial?.Id ?? 0;
            dto.Grade = model.Grade?.Type ?? 0;
            dto.Shooting = model.BasicStatus.Shooting;
            dto.Melee = model.BasicStatus.Melee;
            dto.Accuracy = model.BasicStatus.Accuracy;
            dto.Evasion = model.BasicStatus.Evasion;
            dto.Awakened = model.BasicStatus.Awakened;
            dto.Defense = model.BasicStatus.Defense;
            dto.PracticedShooting = model.PracticedStatus.Shooting;
            dto.PracticedMelee = model.PracticedStatus.Melee;
            dto.PracticedAccuracy = model.PracticedStatus.Accuracy;
            dto.PracticedEvasion = model.PracticedStatus.Evasion;
            dto.PracticedAwakened = model.PracticedStatus.Awakened;
            dto.PracticedDefense = model.PracticedStatus.Defense;
            dto.SkillId = model.Skill?.Id ?? 0;
            dto.AbilityId1 = model.Ability1?.Id;
            dto.AbilityId2 = model.Ability2?.Id;
            dto.AbilityId3 = model.Ability3?.Id;

            dto.TagMaps.Clear();
            dto.TagMaps.AddRange(model.Tags
                .Select(m => new PilotTagMapDto()
                {
                    PilotId = dto.Id,
                    TagId = m.Id,
                    Pilot = dto,
                    // TODO: 設定必要？
                    // Tag = ,
                }));
        });
}
