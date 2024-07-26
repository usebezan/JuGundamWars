using Ju.GundamWars.Client.Boosts.Domain;
using Ju.GundamWars.Client.CuspaKinds.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.Cuspas.Domain;

namespace Ju.GundamWars.Client.Cuspas.Domain.Service;

public class CuspaModelMapper(CuspaKindInventory cuspaKinds, BoostStatusInventory boostStatuses, TagInventory tags) : IMapper<CuspaDto, Cuspa>
{
    public Cuspa Map(CuspaDto dto, Cuspa model) =>
        model.Initialize(() =>
        {
            model.IsChecked = false;

            model.Id = dto.Id;
            model.ForUnitType = dto.ForUnitType;
            model.CuspaKind = cuspaKinds.FirstOrDefault(i => i.Type == dto.CuspaKindType);
            model.Level = dto.Level;
            model.BoostStatus = boostStatuses.FirstOrDefault(i => i.Type == dto.BoostStatusType);

            model.BasicValue = dto.BasicValue;
            model.BonusStatus.Hp = dto.BonusHp;
            model.BonusStatus.BeamAttack = dto.BonusBeamAttack;
            model.BonusStatus.PhysicalAttack = dto.BonusPhysicalAttack;
            model.BonusStatus.BeamDefence = dto.BonusBeamDefence;
            model.BonusStatus.PhysicalDefence = dto.BonusPhysicalDefence;
            model.BonusStatus.CriticalRate = dto.BonusCriticalRate;
            model.BonusStatus.CriticalDamage = dto.BonusCriticalDamage;
            model.BonusStatus.Accuracy = dto.BonusAccuracy;
            model.BonusStatus.Evasion = dto.BonusEvasion;
            model.BonusStatus.Mobility = dto.BonusMobility;
            model.BonusStatus.EnRecovery = dto.BonusEnRecovery;

            model.Memo = dto.Memo;

            model.Tags.ReAddRange(dto.TagMaps
                .Select(d => tags.FirstOrDefault(i => i.Id == d.TagId))
                .Where(i => i != null)
                .Select(i => i!));
        });
}
