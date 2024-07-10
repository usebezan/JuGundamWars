using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Dto;
using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Model;
using Ju.GundamWars.Common.Domain.Service.Mapping;
using Ju.GundamWars.CoMobiles.Domain.Dto;
using Ju.GundamWars.Domain.CoMobiles.Dto;
using Ju.GundamWars.Domain.CoMobiles.Entities;
using Ju.GundamWars.Domain.Txns.CoMobiles.Dto;

namespace Ju.GundamWars.BizTxn._.CoMobiles.Domain.Service.Mapping;

public class CoMobileMapper : IMapper<CoMobileSubject, CoMobile>
{

    public CoMobile Map(CoMobileSubject subject, CoMobile entity)
    {
        entity.Id = subject.Id;
        entity.Name = subject.Name;
        entity.Category = subject.Category?.Type ?? 0;
        entity.SerialId = subject.Serial?.Id ?? 0;
        entity.Role = subject.Role?.Type ?? 0;
        entity.Level = subject.Level;
        entity.Hp = subject.BasicStatus.Hp;
        entity.BeamAttack = subject.BasicStatus.BeamAttack;
        entity.PhysicalAttack = subject.BasicStatus.PhysicalAttack;
        entity.BeamDefence = subject.BasicStatus.BeamDefence;
        entity.PhysicalDefence = subject.BasicStatus.PhysicalDefence;
        entity.CriticalDamage = subject.BasicStatus.CriticalDamage;
        entity.Accuracy = subject.BasicStatus.Accuracy;
        entity.Evasion = subject.BasicStatus.Evasion;
        entity.Mobility = subject.BasicStatus.Mobility;
        entity.UpgradedHp = subject.UpgradedStatus.Hp;
        entity.UpgradedBeamAttack = subject.UpgradedStatus.BeamAttack;
        entity.UpgradedPhysicalAttack = subject.UpgradedStatus.PhysicalAttack;
        entity.UpgradedBeamDefence = subject.UpgradedStatus.BeamDefence;
        entity.UpgradedPhysicalDefence = subject.UpgradedStatus.PhysicalDefence;
        entity.UpgradedCriticalDamage = subject.UpgradedStatus.CriticalDamage;
        entity.UpgradedAccuracy = subject.UpgradedStatus.Accuracy;
        entity.UpgradedEvasion = subject.UpgradedStatus.Evasion;
        entity.UpgradedMobility = subject.UpgradedStatus.Mobility;
        entity.HpUpgradedCount = subject.UpgradedCount.Hp;
        entity.BeamAttackUpgradedCount = subject.UpgradedCount.BeamAttack;
        entity.PhysicalAttackUpgradedCount = subject.UpgradedCount.PhysicalAttack;
        entity.BeamDefenceUpgradedCount = subject.UpgradedCount.BeamDefence;
        entity.PhysicalDefenceUpgradedCount = subject.UpgradedCount.PhysicalDefence;
        entity.CriticalDamageUpgradedCount = subject.UpgradedCount.CriticalDamage;
        entity.AccuracyUpgradedCount = subject.UpgradedCount.Accuracy;
        entity.EvasionUpgradedCount = subject.UpgradedCount.Evasion;
        entity.MobilityUpgradedCount = subject.UpgradedCount.Mobility;
        entity.StartupUpgradedCount = subject.UpgradedCount.Startup;
        entity.SuperMoveUpgradedCount = subject.UpgradedCount.SuperMove;
        entity.Memo = subject.Memo;
        entity.IsPinned = subject.IsPinned;

        entity.TagMaps.AddRange(subject.Tags.Select(s => new CoMobileTagMap()
        {
            CoMobileId = entity.Id,
            TagId = s.Id,
            CoMobile = entity,
        }));

        return entity;
    }

}
