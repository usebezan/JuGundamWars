using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.Cuspas.Domain;

namespace Ju.GundamWars.Client.Cuspas.Domain.Service;

public class CuspaDtoMapper : IMapper<Cuspa, CuspaDto>
{
    public CuspaDto Map(Cuspa model, CuspaDto dto)
    {
        dto.Id = model.Id;
        dto.ForUnitType = model.ForUnitType;
        dto.CuspaKindType = model.CuspaKind?.Type ?? 0;
        dto.Level = model.Level;
        dto.BoostStatusType = model.BoostStatus?.Type ?? 0;
        dto.BasicValue = model.BasicValue;
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
        dto.Memo = model.Memo;

        dto.TagLinks.Clear();
        dto.TagLinks.AddRange(model.Tags
            .Select(m => new CuspaTagMapDto()
            {
                CuspaId = dto.Id,
                TagId = m.Id,
            }));

        return dto;
    }
}
