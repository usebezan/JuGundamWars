using Ju.GundamWars.BizTxn.CoMobiles.Domain.Dto;
using Ju.GundamWars.BizTxn.CoMobiles.Domain.Model;

namespace Ju.GundamWars.BizTxn.CoMobiles.Domain.Service.Mapping;

public class CoMobileDtoMapper : CoMobileMapperBase<CoMobile, CoMobileDto>
{
    public override CoMobileDto Map(CoMobile model, CoMobileDto dto) =>
        Map(model, dto, () =>
        {
            dto.SerialId = model.Serial?.Id ?? 0;
            dto.Role = model.Role?.Type ?? 0;

            dto.Hp = model.BasicStatus.Hp;
            dto.BeamAttack = model.BasicStatus.BeamAttack;
            dto.PhysicalAttack = model.BasicStatus.PhysicalAttack;
            dto.BeamDefence = model.BasicStatus.BeamDefence;
            dto.PhysicalDefence = model.BasicStatus.PhysicalDefence;
            dto.CriticalDamage = model.BasicStatus.CriticalDamage;
            dto.Accuracy = model.BasicStatus.Accuracy;
            dto.Evasion = model.BasicStatus.Evasion;
            dto.Mobility = model.BasicStatus.Mobility;

            dto.UpgradedHp = model.UpgradedStatus.Hp;
            dto.UpgradedBeamAttack = model.UpgradedStatus.BeamAttack;
            dto.UpgradedPhysicalAttack = model.UpgradedStatus.PhysicalAttack;
            dto.UpgradedBeamDefence = model.UpgradedStatus.BeamDefence;
            dto.UpgradedPhysicalDefence = model.UpgradedStatus.PhysicalDefence;
            dto.UpgradedCriticalDamage = model.UpgradedStatus.CriticalDamage;
            dto.UpgradedAccuracy = model.UpgradedStatus.Accuracy;
            dto.UpgradedEvasion = model.UpgradedStatus.Evasion;
            dto.UpgradedMobility = model.UpgradedStatus.Mobility;

            dto.HpUpgradedCount = model.UpgradedCount.Hp;
            dto.BeamAttackUpgradedCount = model.UpgradedCount.BeamAttack;
            dto.PhysicalAttackUpgradedCount = model.UpgradedCount.PhysicalAttack;
            dto.BeamDefenceUpgradedCount = model.UpgradedCount.BeamDefence;
            dto.PhysicalDefenceUpgradedCount = model.UpgradedCount.PhysicalDefence;
            dto.CriticalDamageUpgradedCount = model.UpgradedCount.CriticalDamage;
            dto.AccuracyUpgradedCount = model.UpgradedCount.Accuracy;
            dto.EvasionUpgradedCount = model.UpgradedCount.Evasion;
            dto.MobilityUpgradedCount = model.UpgradedCount.Mobility;
            dto.StartupUpgradedCount = model.UpgradedCount.Startup;
            dto.SuperMoveUpgradedCount = model.UpgradedCount.SuperMove;

            dto.TagMaps.Clear();
            dto.TagMaps.AddRange(model.Tags
                .Select(m => new CoMobileTagMapDto()
                {
                    CoMobileId = dto.Id,
                    TagId = m.Id,
                    CoMobile = dto,
                    // TODO: 設定必要？
                    // Tag = ,
                }));
        });
}
