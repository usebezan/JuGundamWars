using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Cuspas;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Cuspas;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Pilots;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.Domain.Mobiles.Appliers;

public class MobileSubjectApplier(
    ICategoryInventory categoryInventory,
    ISerialInventory serialInventory,
    IMobileKindInventory mobileKindInventory,
    IRoleInventory roleInventory,
    IPositionInventory positionInventory,
    IGradeInventory gradeInventory,
    ITerrainInventory terrainInventory,
    IHasAceInventory hasAceInventory,
    IMobileSSkillInventory mobileSSkillInventory,
    IPilotInventory pilotInventory,
    ICuspaInventory cuspaInventory,
    ISupportInventory supportInventory,
    ICoMobileInventory coMobileInventory,
    IMobileInventory mobileInventory,
    ITagInventory tagInventory)
    : IApplier<Mobile, MobileSubject>
{

    public MobileSubject Apply(Mobile entity, MobileSubject subject)
    {
        subject.Initialize(() =>
        {
            subject.Id = entity.Id;
            subject.Name = entity.Name;
            subject.Blueprint = entity.Blueprint;
            subject.Proof = entity.Proof;
            subject.Level = entity.Level;
            subject.Version = entity.Version;
            subject.SuperEnGrade = entity.SuperEnGrade;
            subject.AceEnGrade = entity.AceEnGrade;
            subject.EnTank = entity.EnTank;
            subject.SSkillText1 = entity.SSkillText1;
            subject.SSkillText2 = entity.SSkillText2;
            subject.SupportProof = entity.SupportProof;
            subject.SupportUnlock = entity.SupportUnlock;
            subject.Memo = entity.Memo;
            subject.IsPinned = entity.IsPinned;

            subject.BasicStatus.Hp = entity.Hp;
            subject.BasicStatus.BeamAttack = entity.BeamAttack;
            subject.BasicStatus.PhysicalAttack = entity.PhysicalAttack;
            subject.BasicStatus.BeamDefence = entity.BeamDefence;
            subject.BasicStatus.PhysicalDefence = entity.PhysicalDefence;
            subject.BasicStatus.CriticalRate = entity.CriticalRate;
            subject.BasicStatus.CriticalDamage = entity.CriticalDamage;
            subject.BasicStatus.Accuracy = entity.Accuracy;
            subject.BasicStatus.Evasion = entity.Evasion;
            subject.BasicStatus.Mobility = entity.Mobility;
            subject.BasicStatus.SuperEnRecovery = entity.SuperEnRecovery;
            subject.BasicStatus.AceEnRecovery = entity.AceEnRecovery;

            subject.RemodeledStatus.Hp = entity.RemodeledHp;
            subject.RemodeledStatus.BeamAttack = entity.RemodeledBeamAttack;
            subject.RemodeledStatus.PhysicalAttack = entity.RemodeledPhysicalAttack;
            subject.RemodeledStatus.BeamDefence = entity.RemodeledBeamDefence;
            subject.RemodeledStatus.PhysicalDefence = entity.RemodeledPhysicalDefence;
            subject.RemodeledStatus.CriticalRate = entity.RemodeledCriticalRate;
            subject.RemodeledStatus.CriticalDamage = entity.RemodeledCriticalDamage;
            subject.RemodeledStatus.Accuracy = entity.RemodeledAccuracy;
            subject.RemodeledStatus.Evasion = entity.RemodeledEvasion;
            subject.RemodeledStatus.Mobility = entity.RemodeledMobility;
            subject.RemodeledStatus.EnRecovery = entity.RemodeledEnRecovery;

            subject.Category = categoryInventory.FirstOrDefault(i => i.Type == entity.Category);
            subject.Serial = serialInventory.FirstOrDefault(i => i.Id == entity.SerialId);
            subject.Kind = mobileKindInventory.FirstOrDefault(i => i.Type == entity.Kind);
            subject.Role = roleInventory.FirstOrDefault(i => i.Type == entity.Role);
            subject.DefaultPosition = positionInventory.FirstOrDefault(i => i.Type == entity.DefaultPosition);
            subject.InitialGrade = gradeInventory.FirstOrDefault(i => i.Type == entity.InitialGrade);
            subject.Terrain1 = terrainInventory.FirstOrDefault(i => i.Type == entity.Terrain1);
            subject.Terrain2 = terrainInventory.FirstOrDefault(i => i.Type == entity.Terrain2);
            subject.Terrain3 = terrainInventory.FirstOrDefault(i => i.Type == entity.Terrain3);
            subject.Grade = gradeInventory.FirstOrDefault(i => i.Type == entity.Grade);
            subject.HasAce = hasAceInventory.FirstOrDefault(i => i.Type == entity.HasAce);
            subject.SSkill1 = mobileSSkillInventory.FirstOrDefault(i => i.Id == entity.SSkillId1);
            subject.SSkill2 = mobileSSkillInventory.FirstOrDefault(i => i.Id == entity.SSkillId2);

            subject.PairId = entity.PairMaps.FirstOrDefault()?.PairId;
            subject.Pair = mobileInventory.FirstOrDefault(i => i.Id == subject.PairId);
            subject.Pilot = pilotInventory.FirstOrDefault(i => i.Id == entity.PilotMaps.FirstOrDefault()?.PilotId);
            if (subject.Pilot != null)
            {
                subject.Pilot.Mobile = subject;
            }
            subject.Cuspa1 = GetCuspa(entity, 1);
            subject.Cuspa2 = GetCuspa(entity, 2);
            subject.Cuspa3 = GetCuspa(entity, 3);
            subject.Cuspa4 = GetCuspa(entity, 4);
            subject.Cuspa5 = GetCuspa(entity, 5);
            subject.Cuspa6 = GetCuspa(entity, 6);
            subject.SCuspa1 = GetCuspa(entity, 11);
            subject.SCuspa2 = GetCuspa(entity, 12);
            subject.SCuspa3 = GetCuspa(entity, 13);
            subject.SCuspa4 = GetCuspa(entity, 14);
            subject.Support1 = GetSupport(entity, 1, subject);
            subject.Support2 = GetSupport(entity, 2, subject);
            subject.Support3 = GetSupport(entity, 3, subject);
            subject.Support4 = GetSupport(entity, 4, subject);
            subject.CoMobile1 = GetCoMobile(entity, 1, subject);
            subject.CoMobile2 = GetCoMobile(entity, 2, subject);
            subject.CoMobile3 = GetCoMobile(entity, 3, subject);

            subject.SubSerials.Clear();
            entity.SubSerialMaps.ForEach(m =>
            {
                var serial = serialInventory.FirstOrDefault(i => i.Id == m.SerialId);
                if (serial != null)
                {
                    subject.SubSerials.Add(serial);
                }
            });

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

    private CuspaSubject? GetCuspa(Mobile entity, byte seq) =>
        cuspaInventory.FirstOrDefault(i => i.Id == (entity.Cuspas.FirstOrDefault(r => r.Seq == seq)?.CuspaId ?? -1));

    private SupportSubject? GetSupport(Mobile entity, byte seq, MobileSubject subject)
    {
        var support = supportInventory.FirstOrDefault(i => i.Id == (entity.Supports.FirstOrDefault(r => r.Seq == seq)?.SupportId ?? -1));
        if (support != null)
        {
            support.Mobile = subject;
        }
        return support;
    }

    private CoMobileSubject? GetCoMobile(Mobile entity, byte seq, MobileSubject subject)
    {
        var coMobile = coMobileInventory.FirstOrDefault(i => i.Id == (entity.CoMobiles.FirstOrDefault(r => r.Seq == seq)?.CoMobileId ?? -1));
        if (coMobile != null)
        {
            coMobile.Mobile = subject;
        }
        return coMobile;
    }

}
