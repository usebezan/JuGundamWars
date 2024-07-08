using Ju.GundamWars.Domain.Common.Service.Mapping;
using Ju.GundamWars.Domain.Cuspas.Entities;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;

namespace Ju.GundamWars.Domain.Cuspas.Appliers;

public class CuspaSubjectApplier(
    ICategoryInventory categoryInventory,
    ICuspaKindInventory cuspaKindInventory,
    ITagInventory tagInventory)
    : IApplier<Cuspa, CuspaSubject>
{

    public CuspaSubject Apply(Cuspa entity, CuspaSubject subject)
    {
        subject.Initialize(() =>
        {
            subject.Id = entity.Id;
            subject.SubName = entity.Name;
            subject.Level = entity.Level;
            subject.Memo = entity.Memo;

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
            subject.BasicStatus.EnRecovery = entity.EnRecovery;

            subject.BonusStatus.Hp = entity.BonusHp;
            subject.BonusStatus.BeamAttack = entity.BonusBeamAttack;
            subject.BonusStatus.PhysicalAttack = entity.BonusPhysicalAttack;
            subject.BonusStatus.BeamDefence = entity.BonusBeamDefence;
            subject.BonusStatus.PhysicalDefence = entity.BonusPhysicalDefence;
            subject.BonusStatus.CriticalRate = entity.BonusCriticalRate;
            subject.BonusStatus.CriticalDamage = entity.BonusCriticalDamage;
            subject.BonusStatus.Accuracy = entity.BonusAccuracy;
            subject.BonusStatus.Evasion = entity.BonusEvasion;
            subject.BonusStatus.Mobility = entity.BonusMobility;
            subject.BonusStatus.EnRecovery = entity.BonusEnRecovery;

            subject.Category = categoryInventory.FirstOrDefault(i => i.Type == entity.Category);
            subject.Kind = cuspaKindInventory.FirstOrDefault(i => i.Type == entity.Kind);

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
