using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.Boosts.Domain;

namespace Ju.GundamWars.Client.Cuspas.Domain;

public partial class CuspaStatus : ModelBase
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
    private int _CriticalRate;
    [ObservableProperty]
    private int _CriticalDamage;
    [ObservableProperty]
    private int _Accuracy;
    [ObservableProperty]
    private int _Evasion;
    [ObservableProperty]
    private int _Mobility;
    [ObservableProperty]
    private int _EnRecovery;


    public CuspaStatus Reset()
    {
        Hp = 0;
        BeamAttack = 0;
        PhysicalAttack = 0;
        BeamDefence = 0;
        PhysicalDefence = 0;
        CriticalRate = 0;
        CriticalDamage = 0;
        Accuracy = 0;
        Evasion = 0;
        Mobility = 0;
        EnRecovery = 0;
        return this;
    }

    public CuspaStatus Reset(BoostStatusType type, int value)
    {
        Hp = type == BoostStatusType.Hp ? value : 0;
        BeamAttack = type == BoostStatusType.BeamAttack ? value : 0;
        PhysicalAttack = type == BoostStatusType.PhysicalAttack ? value : 0;
        BeamDefence = type == BoostStatusType.BeamDefence ? value : 0;
        PhysicalDefence = type == BoostStatusType.PhysicalDefence ? value : 0;
        CriticalRate = type == BoostStatusType.CriticalRate ? value : 0;
        CriticalDamage = type == BoostStatusType.CriticalDamage ? value : 0;
        Accuracy = type == BoostStatusType.Accuracy ? value : 0;
        Evasion = type == BoostStatusType.Evasion ? value : 0;
        Mobility = type == BoostStatusType.Mobility ? value : 0;
        EnRecovery = type == BoostStatusType.EnRecovery ? value : 0;
        return this;
    }

    public CuspaStatus Set(CuspaStatus status)
    {
        Hp = status.Hp;
        BeamAttack = status.BeamAttack;
        PhysicalAttack = status.PhysicalAttack;
        BeamDefence = status.BeamDefence;
        PhysicalDefence = status.PhysicalDefence;
        CriticalRate = status.CriticalRate;
        CriticalDamage = status.CriticalDamage;
        Accuracy = status.Accuracy;
        Evasion = status.Evasion;
        Mobility = status.Mobility;
        EnRecovery = status.EnRecovery;
        return this;
    }

    public CuspaStatus Add(CuspaStatus status)
    {
        Hp += status.Hp;
        BeamAttack += status.BeamAttack;
        PhysicalAttack += status.PhysicalAttack;
        BeamDefence += status.BeamDefence;
        PhysicalDefence += status.PhysicalDefence;
        CriticalRate += status.CriticalRate;
        CriticalDamage += status.CriticalDamage;
        Accuracy += status.Accuracy;
        Evasion += status.Evasion;
        Mobility += status.Mobility;
        EnRecovery += status.EnRecovery;
        return this;
    }

    public CuspaStatus Add(BoostStatusType type, int value)
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
            case BoostStatusType.CriticalRate:
                CriticalRate += value;
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
            case BoostStatusType.EnRecovery:
                EnRecovery += value;
                break;
        }
        return this;
    }

    public CuspaStatus AddWithBonus(CuspaStatus status, int multiplier)
    {
        Hp += status.Hp.Multiply1k(multiplier);
        BeamAttack += status.BeamAttack.Multiply1k(multiplier);
        PhysicalAttack += status.PhysicalAttack.Multiply1k(multiplier);
        BeamDefence += status.BeamDefence.Multiply1k(multiplier);
        PhysicalDefence += status.PhysicalDefence.Multiply1k(multiplier);
        CriticalRate += status.CriticalRate.Multiply1k(multiplier);
        CriticalDamage += status.CriticalDamage.Multiply1k(multiplier);
        Accuracy += status.Accuracy.Multiply1k(multiplier);
        Evasion += status.Evasion.Multiply1k(multiplier);
        Mobility += status.Mobility.Multiply1k(multiplier);
        EnRecovery += status.EnRecovery.Multiply1k(multiplier);
        return this;
    }

    public string ToText()
    {
        return "TODO:";
    }

}
