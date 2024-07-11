using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizConst.Boosts.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizTxn.Supports.Domain.Model;

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

    public SupportStatus Add(BoostStatusType type, int value)
    {
        switch (type)
        {
            case BoostStatusType.Hp:
                Hp += value;
                break;
            case BoostStatusType.BeamAttack:
                BeamAttack += value;
                break;
            case BoostStatusType.PhysicalAttack:
                PhysicalAttack += value;
                break;
            case BoostStatusType.BeamDefence:
                BeamDefence += value;
                break;
            case BoostStatusType.PhysicalDefence:
                PhysicalDefence += value;
                break;
            case BoostStatusType.CriticalDamage:
                CriticalDamage += value;
                break;
            case BoostStatusType.Accuracy:
                Accuracy += value;
                break;
            case BoostStatusType.Evasion:
                Evasion += value;
                break;
            case BoostStatusType.Mobility:
                Mobility += value;
                break;
            case BoostStatusType.SuperPower:
                SuperPower += value;
                break;
            case BoostStatusType.AcePower:
                AcePower += value;
                break;
            case BoostStatusType.RecoveryPower:
                RecoveryPower += value;
                break;
            case BoostStatusType.EnRecovery:
                EnRecovery += value;
                break;
        }
        return this;
    }

}
