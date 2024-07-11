using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;
using Ju.GundamWars.BizTxn.Cuspas.Domain.Model;

namespace Ju.GundamWars.BizTxn.Cuspas.Domain.Service.Mapping;

public class CuspaDtoMapper : CuspaMapperBase<Cuspa, CuspaDto>
{
    public override CuspaDto Map(Cuspa model, CuspaDto dto) =>
        Map(model, dto, () =>
        {
            dto.Kind = model.Kind?.Type ?? 0;
            dto.BoostStatus = model.BoostStatus?.Type ?? 0;

            dto.BonusHp = model.BonusStatus.Hp;
            dto.BonusBeamAttack = model.BonusStatus.BeamAttack;
            dto.BonusPhysicalAttack = model.BonusStatus.PhysicalAttack;
            dto.BonusBeamDefence = model.BonusStatus.BeamDefence;
            dto.BonusPhysicalDefence = model.BonusStatus.PhysicalDefence;
            dto.BonusCriticalRate = model.BonusStatus.CriticalRate;
            dto.BonusCriticalDamage = model.BonusStatus.CriticalDamage;
            dto.BonusAccuracy = model.BonusStatus.Accuracy;
            dto.BonusEvasion = model.BonusStatus.Evasion;
            dto.BonusMobility = model.BonusStatus.Mobility;
            dto.BonusEnRecovery = model.BonusStatus.EnRecovery;

            dto.TagMaps.Clear();
            dto.TagMaps.AddRange(model.Tags
                .Select(m => new CuspaTagMapDto()
                {
                    CuspaId = dto.Id,
                    TagId = m.Id,
                    Cuspa = dto,
                    // TODO: 設定必要？
                    // Tag = ,
                }));
        });
}
