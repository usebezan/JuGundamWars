using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Dto;
using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Model;
using Ju.GundamWars.Common.Domain.Service.Mapping;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.BizTxn._.CoMobiles.Domain.Service.Mapping;

public class CoMobileSubjectMapper(
    ICategoryInventory categoryInventory,
    ISerialInventory serialInventory,
    IRoleInventory roleInventory,
    ITagInventory tagInventory)
    : IMapper<CoMobile, CoMobileSubject>
{

    public CoMobileSubject Map(CoMobile entity, CoMobileSubject subject)
    {
        subject.Initialize(() =>
        {
            subject.Id = entity.Id;
            subject.Name = entity.Name;
            subject.Level = entity.Level;
            subject.Memo = entity.Memo;
            subject.IsPinned = entity.IsPinned;

            subject.BasicStatus.Hp = entity.Hp;
            subject.BasicStatus.BeamAttack = entity.BeamAttack;
            subject.BasicStatus.PhysicalAttack = entity.PhysicalAttack;
            subject.BasicStatus.BeamDefence = entity.BeamDefence;
            subject.BasicStatus.PhysicalDefence = entity.PhysicalDefence;
            subject.BasicStatus.CriticalDamage = entity.CriticalDamage;
            subject.BasicStatus.Accuracy = entity.Accuracy;
            subject.BasicStatus.Evasion = entity.Evasion;
            subject.BasicStatus.Mobility = entity.Mobility;

            subject.UpgradedStatus.Hp = entity.UpgradedHp;
            subject.UpgradedStatus.BeamAttack = entity.UpgradedBeamAttack;
            subject.UpgradedStatus.PhysicalAttack = entity.UpgradedPhysicalAttack;
            subject.UpgradedStatus.BeamDefence = entity.UpgradedBeamDefence;
            subject.UpgradedStatus.PhysicalDefence = entity.UpgradedPhysicalDefence;
            subject.UpgradedStatus.CriticalDamage = entity.UpgradedCriticalDamage;
            subject.UpgradedStatus.Accuracy = entity.UpgradedAccuracy;
            subject.UpgradedStatus.Evasion = entity.UpgradedEvasion;
            subject.UpgradedStatus.Mobility = entity.UpgradedMobility;

            subject.UpgradedCount.Hp = entity.HpUpgradedCount;
            subject.UpgradedCount.BeamAttack = entity.BeamAttackUpgradedCount;
            subject.UpgradedCount.PhysicalAttack = entity.PhysicalAttackUpgradedCount;
            subject.UpgradedCount.BeamDefence = entity.BeamDefenceUpgradedCount;
            subject.UpgradedCount.PhysicalDefence = entity.PhysicalDefenceUpgradedCount;
            subject.UpgradedCount.CriticalDamage = entity.CriticalDamageUpgradedCount;
            subject.UpgradedCount.Accuracy = entity.AccuracyUpgradedCount;
            subject.UpgradedCount.Evasion = entity.EvasionUpgradedCount;
            subject.UpgradedCount.Mobility = entity.MobilityUpgradedCount;
            subject.UpgradedCount.Startup = entity.StartupUpgradedCount;
            subject.UpgradedCount.SuperMove = entity.SuperMoveUpgradedCount;

            subject.Category = categoryInventory.FirstOrDefault(i => i.Type == entity.Category);
            subject.Serial = serialInventory.FirstOrDefault(i => i.Id == entity.SerialId);
            subject.Role = roleInventory.FirstOrDefault(i => i.Type == entity.Role);

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
