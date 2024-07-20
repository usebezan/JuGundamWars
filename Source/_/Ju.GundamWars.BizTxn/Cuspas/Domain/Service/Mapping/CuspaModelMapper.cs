using Ju.GundamWars.BizConst.CuspaKinds.Domain;
using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;
using Ju.GundamWars.BizTxn.Cuspas.Domain.Model;
using Ju.GundamWars.BizTxn.Tags.Domain.Inventory;

namespace Ju.GundamWars.BizTxn.Cuspas.Domain.Service.Mapping;

public class CuspaModelMapper(
    CuspaKindInventory cuspaKindInventory,
    BoostStatusInventory boostStatusInventory,
    TagInventory tagInventory) : CuspaMapperBase<CuspaDto, Cuspa>
{
    public override Cuspa Map(CuspaDto dto, Cuspa model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;

            model.Kind = cuspaKindInventory.FirstOrDefault(i => i.Type == dto.Kind);
            model.BoostStatus = boostStatusInventory.FirstOrDefault(i => i.Type == dto.BoostStatus);

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

            model.Tags.ReAddRange(dto.TagMaps
                .Select(d => tagInventory.FirstOrDefault(i => i.Id == d.TagId))
                .Where(i => i != null)
                .Select(i => i!));
        });
}
