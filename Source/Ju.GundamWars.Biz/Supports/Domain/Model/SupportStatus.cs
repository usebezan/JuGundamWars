using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizMaster.SupportStatuses.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Biz.Supports.Domain.Model;

public partial class SupportStatus : ModelBase
{

    [ObservableProperty]
    private int _Hp;
    [ObservableProperty]
    private int _BeamAttack;
    [ObservableProperty]
    private int _PhysicalAttack;
    [ObservableProperty]
    private int _BeamDefence;
    [ObservableProperty]
    private int _PhysicalDefence;
    [ObservableProperty]
    private int _CriticalDamage;
    [ObservableProperty]
    private int _Accuracy;
    [ObservableProperty]
    private int _Evasion;
    [ObservableProperty]
    private int _Mobility;
    [ObservableProperty]
    private int _SuperPower;
    [ObservableProperty]
    private int _AcePower;
    [ObservableProperty]
    private int _RecoveryPower;
    [ObservableProperty]
    private int _EnRecovery;


    public SupportStatus Reset()
    {
        Hp = 0;
        BeamAttack = 0;
        PhysicalAttack = 0;
        BeamDefence = 0;
        PhysicalDefence = 0;
        CriticalDamage = 0;
        Accuracy = 0;
        Evasion = 0;
        Mobility = 0;
        SuperPower = 0;
        AcePower = 0;
        RecoveryPower = 0;
        EnRecovery = 0;
        return this;
    }

    public SupportStatus Set(SupportStatus status)
    {
        Hp = status.Hp;
        BeamAttack = status.BeamAttack;
        PhysicalAttack = status.PhysicalAttack;
        BeamDefence = status.BeamDefence;
        PhysicalDefence = status.PhysicalDefence;
        CriticalDamage = status.CriticalDamage;
        Accuracy = status.Accuracy;
        Evasion = status.Evasion;
        Mobility = status.Mobility;
        SuperPower = status.SuperPower;
        AcePower = status.AcePower;
        RecoveryPower = status.RecoveryPower;
        EnRecovery = status.EnRecovery;
        return this;
    }

    public SupportStatus Add(SupportStatus status)
    {
        Hp += status.Hp;
        BeamAttack += status.BeamAttack;
        PhysicalAttack += status.PhysicalAttack;
        BeamDefence += status.BeamDefence;
        PhysicalDefence += status.PhysicalDefence;
        CriticalDamage += status.CriticalDamage;
        Accuracy += status.Accuracy;
        Evasion += status.Evasion;
        Mobility += status.Mobility;
        SuperPower += status.SuperPower;
        AcePower += status.AcePower;
        RecoveryPower += status.RecoveryPower;
        EnRecovery += status.EnRecovery;
        return this;
    }

    public SupportStatus Add(SupportStatusType type, int value)
    {
        switch (type)
        {
            case SupportStatusType.Hp:
                Hp += value;
                break;
            case SupportStatusType.BeamAttack:
                BeamAttack += value;
                break;
            case SupportStatusType.PhysicalAttack:
                PhysicalAttack += value;
                break;
            case SupportStatusType.BeamDefence:
                BeamDefence += value;
                break;
            case SupportStatusType.PhysicalDefence:
                PhysicalDefence += value;
                break;
            case SupportStatusType.CriticalDamage:
                CriticalDamage += value;
                break;
            case SupportStatusType.Accuracy:
                Accuracy += value;
                break;
            case SupportStatusType.Evasion:
                Evasion += value;
                break;
            case SupportStatusType.Mobility:
                Mobility += value;
                break;
            case SupportStatusType.SuperPower:
                SuperPower += value;
                break;
            case SupportStatusType.AcePower:
                AcePower += value;
                break;
            case SupportStatusType.RecoveryPower:
                RecoveryPower += value;
                break;
            case SupportStatusType.EnRecovery:
                EnRecovery += value;
                break;
        }
        return this;
    }

}
