using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Share.CoMobiles.Domain;

namespace Ju.GundamWars.Client.CoMobiles.Domain.Service;

public class CoMobileModelMapper(SerialInventory serials, RoleInventory roles, TagInventory tags) : IMapper<CoMobileDto, CoMobile>
{
    public CoMobile Map(CoMobileDto dto, CoMobile model) =>
        model.Initialize(() =>
        {
            model.IsChecked = false;

            model.Id = dto.Id;
            model.Name = dto.Name;
            model.Serial = serials.FirstOrDefault(i => i.Id == dto.SerialId);
            model.Role = roles.FirstOrDefault(i => i.Type == dto.RoleType);
            model.Level = dto.Level;

            //model.BasicStatus.Hp = dto.Hp;
            //model.BasicStatus.BeamAttack = dto.BeamAttack;
            //model.BasicStatus.PhysicalAttack = dto.PhysicalAttack;
            //model.BasicStatus.BeamDefence = dto.BeamDefence;
            //model.BasicStatus.PhysicalDefence = dto.PhysicalDefence;
            //model.BasicStatus.CriticalDamage = dto.CriticalDamage;
            //model.BasicStatus.Accuracy = dto.Accuracy;
            //model.BasicStatus.Evasion = dto.Evasion;
            //model.BasicStatus.Mobility = dto.Mobility;

            //model.UpgradedStatus.Hp = dto.UpgradedHp;
            //model.UpgradedStatus.BeamAttack = dto.UpgradedBeamAttack;
            //model.UpgradedStatus.PhysicalAttack = dto.UpgradedPhysicalAttack;
            //model.UpgradedStatus.BeamDefence = dto.UpgradedBeamDefence;
            //model.UpgradedStatus.PhysicalDefence = dto.UpgradedPhysicalDefence;
            //model.UpgradedStatus.CriticalDamage = dto.UpgradedCriticalDamage;
            //model.UpgradedStatus.Accuracy = dto.UpgradedAccuracy;
            //model.UpgradedStatus.Evasion = dto.UpgradedEvasion;
            //model.UpgradedStatus.Mobility = dto.UpgradedMobility;

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

            model.Memo = dto.Memo;
            model.IsPinned = dto.IsPinned;

            model.Tags.ReAddRange(dto.TagLinks
                .Select(d => tags.FirstOrDefault(i => i.Id == d.TagId))
                .Where(i => i != null)
                .Select(i => i!));
        });
}
