using Ju.GundamWars.Biz._.CoMobiles.Domain.Model;
using Ju.GundamWars.Biz._.Cuspas;
using Ju.GundamWars.Biz._.Mobiles.Domain;
using Ju.GundamWars.Biz._.Mobiles.Domain.Entities;
using Ju.GundamWars.Biz.Supports.Domain.Model;
using Ju.GundamWars.Common.Domain.Service.Mapping;
using Ju.GundamWars.Domain.Mobiles.Entities;
using Ju.GundamWars.Mobiles.Domain.Entities;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Appliers;

public class MobileMapper : IMapper<MobileSubject, Mobile>
{

    public Mobile Map(MobileSubject subject, Mobile entity)
    {
        entity.Id = subject.Id;
        entity.Name = subject.Name;
        entity.Category = subject.Category?.Type ?? 0;
        entity.SerialId = subject.Serial?.Id ?? 0;
        entity.Kind = subject.Kind?.Type ?? 0;
        entity.Role = subject.Role?.Type ?? 0;
        entity.DefaultPosition = subject.DefaultPosition?.Type ?? 0;
        entity.InitialGrade = subject.InitialGrade?.Type ?? 0;
        entity.Terrain1 = subject.Terrain1?.Type ?? 0;
        entity.Terrain2 = subject.Terrain2?.Type ?? 0;
        entity.Terrain3 = subject.Terrain3?.Type ?? 0;
        entity.Blueprint = subject.Blueprint;
        entity.Proof = subject.Proof;
        entity.Grade = subject.Grade?.Type ?? 0;
        entity.Level = subject.Level;
        entity.Version = subject.Version;
        entity.Hp = subject.BasicStatus.Hp;
        entity.BeamAttack = subject.BasicStatus.BeamAttack;
        entity.PhysicalAttack = subject.BasicStatus.PhysicalAttack;
        entity.BeamDefence = subject.BasicStatus.BeamDefence;
        entity.PhysicalDefence = subject.BasicStatus.PhysicalDefence;
        entity.CriticalRate = subject.BasicStatus.CriticalRate;
        entity.CriticalDamage = subject.BasicStatus.CriticalDamage;
        entity.Accuracy = subject.BasicStatus.Accuracy;
        entity.Evasion = subject.BasicStatus.Evasion;
        entity.Mobility = subject.BasicStatus.Mobility;
        entity.SuperEnRecovery = subject.BasicStatus.SuperEnRecovery;
        entity.AceEnRecovery = subject.BasicStatus.AceEnRecovery;
        entity.RemodeledHp = subject.RemodeledStatus.Hp;
        entity.RemodeledBeamAttack = subject.RemodeledStatus.BeamAttack;
        entity.RemodeledPhysicalAttack = subject.RemodeledStatus.PhysicalAttack;
        entity.RemodeledBeamDefence = subject.RemodeledStatus.BeamDefence;
        entity.RemodeledPhysicalDefence = subject.RemodeledStatus.PhysicalDefence;
        entity.RemodeledCriticalRate = subject.RemodeledStatus.CriticalRate;
        entity.RemodeledCriticalDamage = subject.RemodeledStatus.CriticalDamage;
        entity.RemodeledAccuracy = subject.RemodeledStatus.Accuracy;
        entity.RemodeledEvasion = subject.RemodeledStatus.Evasion;
        entity.RemodeledMobility = subject.RemodeledStatus.Mobility;
        entity.RemodeledEnRecovery = subject.RemodeledStatus.EnRecovery;
        entity.HasAce = subject.HasAce?.Type ?? 0;
        entity.SuperEnGrade = subject.SuperEnGrade;
        entity.AceEnGrade = subject.AceEnGrade;
        entity.EnTank = subject.EnTank;
        entity.SSkillId1 = subject.SSkill1?.Id;
        entity.SSkillText1 = subject.SSkillText1;
        entity.SSkillId2 = subject.SSkill2?.Id;
        entity.SSkillText2 = subject.SSkillText2;
        entity.SupportProof = subject.SupportProof;
        entity.SupportUnlock = subject.SupportUnlock;
        entity.Memo = subject.Memo;
        entity.IsPinned = subject.IsPinned;

        entity.PairMaps.Clear();
        if (subject.Pair != null)
        {
            entity.PairMaps.Add(new() { MobileId = entity.Id, PairId = subject.Pair.Id, Mobile = entity, });
        }

        entity.SubSerialMaps.Clear();
        entity.SubSerialMaps.AddRange(subject.SubSerials.Select(s => new MobileSubSerialMap()
        {
            MobileId = entity.Id,
            SerialId = s.Id,
            Mobile = entity,
        }));

        entity.TagMaps.Clear();
        entity.TagMaps.AddRange(subject.Tags.Select(s => new MobileTagMap()
        {
            MobileId = entity.Id,
            TagId = s.Id,
            Mobile = entity,
        }));

        entity.PilotMaps.Clear();
        if (subject.Pilot != null)
        {
            entity.PilotMaps.Add(new() { MobileId = entity.Id, PilotId = subject.Pilot.Id, Mobile = entity, });
        }

        entity.Cuspas.Clear();
        AddCuspa(entity, 1, subject.Cuspa1);
        AddCuspa(entity, 2, subject.Cuspa2);
        AddCuspa(entity, 3, subject.Cuspa3);
        AddCuspa(entity, 4, subject.Cuspa4);
        AddCuspa(entity, 5, subject.Cuspa5);
        AddCuspa(entity, 6, subject.Cuspa6);
        AddCuspa(entity, 11, subject.SCuspa1);
        AddCuspa(entity, 12, subject.SCuspa2);
        AddCuspa(entity, 13, subject.SCuspa3);
        AddCuspa(entity, 14, subject.SCuspa4);

        entity.Supports.Clear();
        AddSupport(entity, 1, subject.Support1);
        AddSupport(entity, 2, subject.Support2);
        AddSupport(entity, 3, subject.Support3);
        AddSupport(entity, 4, subject.Support4);

        entity.CoMobiles.Clear();
        AddCoMobile(entity, 1, subject.CoMobile1);
        AddCoMobile(entity, 2, subject.CoMobile2);
        AddCoMobile(entity, 3, subject.CoMobile3);

        return entity;
    }

    private void AddCuspa(Mobile mobile, byte seq, CuspaSubject? cuspa)
    {
        if (cuspa != null)
        {
            mobile.Cuspas.Add(new() { MobileId = mobile.Id, Seq = seq, CuspaId = cuspa.Id, Mobile = mobile, });
        }
    }

    private void AddSupport(Mobile mobile, byte seq, Support? support)
    {
        if (support != null)
        {
            mobile.Supports.Add(new() { MobileId = mobile.Id, Seq = seq, SupportId = support.Id, Mobile = mobile, });
        }
    }

    private void AddCoMobile(Mobile mobile, byte seq, CoMobileSubject? CoMobile)
    {
        if (CoMobile != null)
        {
            mobile.CoMobiles.Add(new() { MobileId = mobile.Id, Seq = seq, CoMobileId = CoMobile.Id, Mobile = mobile, });
        }
    }

}
