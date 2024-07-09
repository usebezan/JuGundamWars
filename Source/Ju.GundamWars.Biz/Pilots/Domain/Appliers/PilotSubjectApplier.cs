using Ju.GundamWars.Common.Domain.Service.Mapping;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.Pilots.Domain.Appliers;

public class PilotSubjectMapper(
    ICategoryInventory categoryInventory,
    ISerialInventory serialInventory,
    IGradeInventory gradeInventory,
    ITagInventory tagInventory,
    IPilotSkillInventory pilotSkillInventory,
    IPilotAbilityInventory pilotAbilityInventory)
    : IMapper<Pilot, PilotSubject>
{

    public PilotSubject Map(Pilot entity, PilotSubject subject)
    {
        subject.Initialize(() =>
        {
            subject.Id = entity.Id;
            subject.Name = entity.Name;
            subject.Level = entity.Level;
            subject.SkillText1 = entity.SkillText1;
            subject.SkillText2 = entity.SkillText2;
            subject.SlotRank1 = entity.SlotRank1;
            subject.SlotRank2 = entity.SlotRank2;
            subject.SlotRank3 = entity.SlotRank3;
            subject.Memo = entity.Memo;
            subject.IsPinned = entity.IsPinned;

            subject.BasicStatus.Shooting = entity.Shooting;
            subject.BasicStatus.Melee = entity.Melee;
            subject.BasicStatus.Accuracy = entity.Accuracy;
            subject.BasicStatus.Evasion = entity.Evasion;
            subject.BasicStatus.Awakened = entity.Awakened;
            subject.BasicStatus.Defense = entity.Defense;

            subject.PracticedStatus.Shooting = entity.PracticedShooting;
            subject.PracticedStatus.Melee = entity.PracticedMelee;
            subject.PracticedStatus.Accuracy = entity.PracticedAccuracy;
            subject.PracticedStatus.Evasion = entity.PracticedEvasion;
            subject.PracticedStatus.Awakened = entity.PracticedAwakened;
            subject.PracticedStatus.Defense = entity.PracticedDefense;

            subject.Category = categoryInventory.FirstOrDefault(i => i.Type == entity.Category);
            subject.Serial = serialInventory.FirstOrDefault(i => i.Id == entity.SerialId);
            subject.Grade = gradeInventory.FirstOrDefault(i => i.Type == entity.Grade);
            subject.Skill = pilotSkillInventory.FirstOrDefault(i => i.Id == entity.SkillId);
            subject.Ability1 = pilotAbilityInventory.FirstOrDefault(i => i.Id == entity.AbilityId1);
            subject.Ability2 = pilotAbilityInventory.FirstOrDefault(i => i.Id == entity.AbilityId2);
            subject.Ability3 = pilotAbilityInventory.FirstOrDefault(i => i.Id == entity.AbilityId3);

            subject.Tags.Clear();
            entity.TagMaps.ForEach(m =>
            {
                var tag = tagInventory.FirstOrDefault(i => i.Id == m.TagId);
                if (tag != null)
                {
                    subject.Tags.Add(tag);
                }
            });
        });
        return subject;
    }

}
