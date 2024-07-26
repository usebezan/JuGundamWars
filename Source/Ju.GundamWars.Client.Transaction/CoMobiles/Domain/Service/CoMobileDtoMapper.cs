using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.Roles.Domain;

namespace Ju.GundamWars.Client.CoMobiles.Domain.Service;

public class CoMobileDtoMapper : IMapper<CoMobile, CoMobileDto>
{
    public CoMobileDto Map(CoMobile model, CoMobileDto dto)
    {
        dto.Id = model.Id;
        dto.Name = model.Name;
        dto.SerialId = model.Serial?.Id ?? 0;
        dto.RoleType = model.Role?.Type ?? RoleType.Unknown;
        dto.Level = model.Level;
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
        dto.Memo = model.Memo;
        dto.IsPinned = model.IsPinned;

        dto.TagMaps.Clear();
        dto.TagMaps.AddRange(model.Tags
            .Select(m => new CoMobileTagMapDto()
            {
                CoMobileId = dto.Id,
                TagId = m.Id,
            }));

        return dto;
    }
}
