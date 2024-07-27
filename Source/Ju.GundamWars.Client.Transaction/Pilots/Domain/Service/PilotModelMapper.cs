using Ju.GundamWars.Client.Grades.Domain;
using Ju.GundamWars.Client.PilotAbilities.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Share.Pilots.Domain;
using Ju.GundamWars.Share.Pilots.Domain.Service;

namespace Ju.GundamWars.Client.Pilots.Domain.Service;

public class PilotModelMapper(SerialInventory serials, GradeInventory grades, PilotSkillInventory pilotSkills, PilotAbilityInventory pilotAbilities, TagInventory tags)
    : PilotMapperBase<PilotDto, PilotStatusRecord, Pilot, PilotStatus>
{
    public override Pilot Map(PilotDto dto, Pilot model) =>
        model.Initialize(() =>
        {
            model.IsChecked = false;
            MapCore(dto, model);
            model.Serial = serials.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Grade = grades.FirstOrDefault(i => i.Type == dto.GradeType);
            model.PilotSkill = pilotSkills.FirstOrDefault(i => i.Id == dto.PilotSkillId);
            model.PilotSlotAbilities.ReAddRange(dto.PilotSlotAbilities.Select(d => new PilotSlotAbility()
            {
                PilotId = d.PilotId,
                Seq = d.Seq,
                SlotRank = d.SlotRank,
                PilotAbilityId = d.PilotAbilityId,
                PilotAbility = pilotAbilities.FirstOrDefault(i => i.Id == d.PilotAbilityId),
            }));
            model.Tags.ReAddRange(dto.TagLinks.Select(d => tags.FirstOrDefault(i => i.Id == d.TagId)).Where(i => i != null).Select(i => i!));
        });
}
