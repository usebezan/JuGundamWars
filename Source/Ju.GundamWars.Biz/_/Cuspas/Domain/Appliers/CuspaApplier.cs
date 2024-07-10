using Ju.GundamWars.Biz._.Cuspas;
using Ju.GundamWars.Biz._.Cuspas.Domain.Entities;
using Ju.GundamWars.Common.Domain.Service.Mapping;
using Ju.GundamWars.Cuspas.Domain.Entities;
using Ju.GundamWars.Domain.Cuspas.Entities;

namespace Ju.GundamWars.Biz._.Cuspas.Domain.Appliers;

public class CuspaMapper : IMapper<CuspaSubject, Cuspa>
{

    public Cuspa Map(CuspaSubject subject, Cuspa entity)
    {
        entity.Id = subject.Id;
        entity.Name = subject.SubName;
        entity.Category = subject.Category?.Type ?? 0;
        entity.Kind = subject.Kind?.Type ?? 0;
        entity.Level = subject.Level;
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
        entity.EnRecovery = subject.BasicStatus.EnRecovery;
        entity.BonusHp = subject.BonusStatus.Hp;
        entity.BonusBeamAttack = subject.BonusStatus.BeamAttack;
        entity.BonusPhysicalAttack = subject.BonusStatus.PhysicalAttack;
        entity.BonusBeamDefence = subject.BonusStatus.BeamDefence;
        entity.BonusPhysicalDefence = subject.BonusStatus.PhysicalDefence;
        entity.BonusCriticalRate = subject.BonusStatus.CriticalRate;
        entity.BonusCriticalDamage = subject.BonusStatus.CriticalDamage;
        entity.BonusAccuracy = subject.BonusStatus.Accuracy;
        entity.BonusEvasion = subject.BonusStatus.Evasion;
        entity.BonusMobility = subject.BonusStatus.Mobility;
        entity.BonusEnRecovery = subject.BonusStatus.EnRecovery;
        entity.Memo = subject.Memo;

        entity.TagMaps.AddRange(subject.Tags.Select(s => new CuspaTagMap()
        {
            CuspaId = entity.Id,
            TagId = s.Id,
            Cuspa = entity,
        }));

        return entity;
    }

}
