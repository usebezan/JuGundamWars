using Ju.GundamWars.Domain.Common.Service.Mapping;
using Ju.GundamWars.Domain.Pilots.Entities;

namespace Ju.GundamWars.Domain.Pilots.Appliers;

public class PilotMapper : IMapper<PilotSubject, Pilot>
{

    public Pilot Map(PilotSubject subject, Pilot entity)
    {
        entity.Id = subject.Id;
        entity.Name = subject.Name;
        entity.Category = subject.Category?.Type ?? 0;
        entity.SerialId = subject.Serial?.Id ?? 0;
        entity.Grade = subject.Grade?.Type ?? 0;
        entity.Level = subject.Level;
        entity.Shooting = subject.BasicStatus.Shooting;
        entity.Melee = subject.BasicStatus.Melee;
        entity.Accuracy = subject.BasicStatus.Accuracy;
        entity.Evasion = subject.BasicStatus.Evasion;
        entity.Awakened = subject.BasicStatus.Awakened;
        entity.Defense = subject.BasicStatus.Defense;
        entity.PracticedShooting = subject.PracticedStatus.Shooting;
        entity.PracticedMelee = subject.PracticedStatus.Melee;
        entity.PracticedAccuracy = subject.PracticedStatus.Accuracy;
        entity.PracticedEvasion = subject.PracticedStatus.Evasion;
        entity.PracticedAwakened = subject.PracticedStatus.Awakened;
        entity.PracticedDefense = subject.PracticedStatus.Defense;
        entity.SkillId = subject.Skill?.Id ?? 0;
        entity.SkillText1 = subject.SkillText1;
        entity.SkillText2 = subject.SkillText2;
        entity.SlotRank1 = subject.SlotRank1;
        entity.AbilityId1 = subject.Ability1?.Id;
        entity.SlotRank2 = subject.SlotRank2;
        entity.AbilityId2 = subject.Ability2?.Id;
        entity.SlotRank3 = subject.SlotRank3;
        entity.AbilityId3 = subject.Ability3?.Id;
        entity.Memo = subject.Memo;
        entity.IsPinned = subject.IsPinned;

        entity.TagMaps.AddRange(subject.Tags.Select(s => new PilotTagMap()
        {
            PilotId = entity.Id,
            TagId = s.Id,
            Pilot = entity,
        }));

        return entity;
    }

}
