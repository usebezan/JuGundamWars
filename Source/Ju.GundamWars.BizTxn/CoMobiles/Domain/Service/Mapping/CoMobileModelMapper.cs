using Ju.GundamWars.BizConst.Roles.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizTxn.CoMobiles.Domain.Dto;
using Ju.GundamWars.BizTxn.CoMobiles.Domain.Model;
using Ju.GundamWars.BizTxn.Tags.Domain.Inventory;

namespace Ju.GundamWars.BizTxn.CoMobiles.Domain.Service.Mapping;

public class CoMobileModelMapper(
    SerialInventory serialInventory,
    RoleInventory roleInventory,
    TagInventory tagInventory) : CoMobileMapperBase<CoMobileDto, CoMobile>
{
    public override CoMobile Map(CoMobileDto dto, CoMobile model) =>
        Map(dto, model, () =>
        {
            model.IsChecked = false;

            model.Serial = serialInventory.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Role = roleInventory.FirstOrDefault(i => i.Type == dto.Role);

            model.BasicStatus.Hp = dto.Hp;
            model.BasicStatus.BeamAttack = dto.BeamAttack;
            model.BasicStatus.PhysicalAttack = dto.PhysicalAttack;
            model.BasicStatus.BeamDefence = dto.BeamDefence;
            model.BasicStatus.PhysicalDefence = dto.PhysicalDefence;
            model.BasicStatus.CriticalDamage = dto.CriticalDamage;
            model.BasicStatus.Accuracy = dto.Accuracy;
            model.BasicStatus.Evasion = dto.Evasion;
            model.BasicStatus.Mobility = dto.Mobility;

            model.UpgradedStatus.Hp = dto.UpgradedHp;
            model.UpgradedStatus.BeamAttack = dto.UpgradedBeamAttack;
            model.UpgradedStatus.PhysicalAttack = dto.UpgradedPhysicalAttack;
            model.UpgradedStatus.BeamDefence = dto.UpgradedBeamDefence;
            model.UpgradedStatus.PhysicalDefence = dto.UpgradedPhysicalDefence;
            model.UpgradedStatus.CriticalDamage = dto.UpgradedCriticalDamage;
            model.UpgradedStatus.Accuracy = dto.UpgradedAccuracy;
            model.UpgradedStatus.Evasion = dto.UpgradedEvasion;
            model.UpgradedStatus.Mobility = dto.UpgradedMobility;

            model.UpgradedCount.Hp = dto.HpUpgradedCount;
            model.UpgradedCount.BeamAttack = dto.BeamAttackUpgradedCount;
            model.UpgradedCount.PhysicalAttack = dto.PhysicalAttackUpgradedCount;
            model.UpgradedCount.BeamDefence = dto.BeamDefenceUpgradedCount;
            model.UpgradedCount.PhysicalDefence = dto.PhysicalDefenceUpgradedCount;
            model.UpgradedCount.CriticalDamage = dto.CriticalDamageUpgradedCount;
            model.UpgradedCount.Accuracy = dto.AccuracyUpgradedCount;
            model.UpgradedCount.Evasion = dto.EvasionUpgradedCount;
            model.UpgradedCount.Mobility = dto.MobilityUpgradedCount;
            model.UpgradedCount.Startup = dto.StartupUpgradedCount;
            model.UpgradedCount.SuperMove = dto.SuperMoveUpgradedCount;

            model.Tags.ReAddRange(dto.TagMaps
                .Select(d => tagInventory.FirstOrDefault(i => i.Id == d.TagId))
                .Where(i => i != null)
                .Select(i => i!));
        });
}
