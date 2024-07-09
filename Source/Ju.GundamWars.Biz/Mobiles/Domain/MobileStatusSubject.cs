using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Biz.Supports.Domain.Model;
using Ju.GundamWars.BizMaster.MobileStatuses;
using Ju.GundamWars.Core;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Cuspas;

namespace Ju.GundamWars.Domain.Mobiles;

public partial class MobileStatusSubject : GwObservableObject
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
    private int _SuperEnRecovery;
    [ObservableProperty]
    private int _AceEnRecovery;

    [ObservableProperty]
    private int _SuperPower;
    [ObservableProperty]
    private int _AcePower;
    [ObservableProperty]
    private int _RecoveryPower;


    public int Get(MobileStatusType type) =>
        type switch
        {
            MobileStatusType.Hp => Hp,
            MobileStatusType.BeamAttack => BeamAttack,
            MobileStatusType.PhysicalAttack => PhysicalAttack,
            MobileStatusType.BeamDefence => BeamDefence,
            MobileStatusType.PhysicalDefence => PhysicalDefence,
            MobileStatusType.CriticalRate => CriticalRate,
            MobileStatusType.CriticalDamage => CriticalDamage,
            MobileStatusType.Accuracy => Accuracy,
            MobileStatusType.Evasion => Evasion,
            MobileStatusType.Mobility => Mobility,
            MobileStatusType.SuperEnRecovery => SuperEnRecovery,
            MobileStatusType.AceEnRecovery => AceEnRecovery,
            MobileStatusType.SuperPower => SuperPower,
            MobileStatusType.AcePower => AcePower,
            MobileStatusType.RecoveryPower => RecoveryPower,
            _ => 0,
        };

    public MobileStatusSubject Reset()
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
        SuperEnRecovery = 0;
        AceEnRecovery = 0;
        SuperPower = 0;
        AcePower = 0;
        RecoveryPower = 0;
        return this;
    }

    public MobileStatusSubject Set(MobileStatusSubject status)
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
        SuperEnRecovery = status.SuperEnRecovery;
        AceEnRecovery = status.AceEnRecovery;
        SuperPower = status.SuperPower;
        AcePower = status.AcePower;
        RecoveryPower = status.RecoveryPower;
        return this;
    }

    public MobileStatusSubject Add(CoMobileStatusSubject boost)
    {
        Hp += boost.Hp;
        BeamAttack += boost.BeamAttack;
        PhysicalAttack += boost.PhysicalAttack;
        BeamDefence += boost.BeamDefence;
        PhysicalDefence += boost.PhysicalDefence;
        CriticalDamage += boost.CriticalDamage;
        Accuracy += boost.Accuracy;
        Evasion += boost.Evasion;
        Mobility += boost.Mobility;
        return this;
    }

    public MobileStatusSubject Add(CuspaStatusSubject boost)
    {
        Hp += boost.Hp;
        BeamAttack += boost.BeamAttack;
        PhysicalAttack += boost.PhysicalAttack;
        BeamDefence += boost.BeamDefence;
        PhysicalDefence += boost.PhysicalDefence;
        CriticalRate += boost.CriticalRate;
        CriticalDamage += boost.CriticalDamage;
        Accuracy += boost.Accuracy;
        Evasion += boost.Evasion;
        Mobility += boost.Mobility;
        SuperEnRecovery += boost.EnRecovery;
        AceEnRecovery += boost.EnRecovery;
        return this;
    }

    public MobileStatusSubject Add(SupportStatusSubject boost)
    {
        Hp += boost.Hp;
        BeamAttack += boost.BeamAttack;
        PhysicalAttack += boost.PhysicalAttack;
        BeamDefence += boost.BeamDefence;
        PhysicalDefence += boost.PhysicalDefence;
        CriticalDamage += boost.CriticalDamage;
        Accuracy += boost.Accuracy;
        Evasion += boost.Evasion;
        Mobility += boost.Mobility;
        SuperEnRecovery += boost.EnRecovery;
        AceEnRecovery += boost.EnRecovery;
        SuperPower += boost.SuperPower;
        AcePower += boost.AcePower;
        RecoveryPower += boost.RecoveryPower;
        return this;
    }

    public MobileStatusSubject Add(MobileRemodeledStatusSubject boost)
    {
        Hp += boost.Hp;
        BeamAttack += boost.BeamAttack;
        PhysicalAttack += boost.PhysicalAttack;
        BeamDefence += boost.BeamDefence;
        PhysicalDefence += boost.PhysicalDefence;
        CriticalRate += boost.CriticalRate;
        CriticalDamage += boost.CriticalDamage;
        Accuracy += boost.Accuracy;
        Evasion += boost.Evasion;
        Mobility += boost.Mobility;
        SuperEnRecovery += boost.EnRecovery;
        AceEnRecovery += boost.EnRecovery;
        return this;
    }

    public MobileStatusSubject Add(MobileStatusSubject status)
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
        SuperEnRecovery += status.SuperEnRecovery;
        AceEnRecovery += status.AceEnRecovery;
        SuperPower += status.SuperPower;
        AcePower += status.AcePower;
        RecoveryPower += status.RecoveryPower;
        return this;
    }

    public MobileStatusSubject Add(MobileStatusType type, int value)
    {
        switch (type)
        {
            case MobileStatusType.Hp:
                Hp += value;
                break;
            case MobileStatusType.BeamAttack:
                BeamAttack += value;
                break;
            case MobileStatusType.PhysicalAttack:
                PhysicalAttack += value;
                break;
            case MobileStatusType.BeamDefence:
                BeamDefence += value;
                break;
            case MobileStatusType.PhysicalDefence:
                PhysicalDefence += value;
                break;
            case MobileStatusType.CriticalRate:
                CriticalRate += value;
                break;
            case MobileStatusType.CriticalDamage:
                CriticalDamage += value;
                break;
            case MobileStatusType.Accuracy:
                Accuracy += value;
                break;
            case MobileStatusType.Evasion:
                Evasion += value;
                break;
            case MobileStatusType.Mobility:
                Mobility += value;
                break;
            case MobileStatusType.SuperEnRecovery:
                SuperEnRecovery += value;
                break;
            case MobileStatusType.AceEnRecovery:
                AceEnRecovery += value;
                break;
            case MobileStatusType.SuperPower:
                SuperPower += value;
                break;
            case MobileStatusType.AcePower:
                AcePower += value;
                break;
            case MobileStatusType.RecoveryPower:
                RecoveryPower += value;
                break;
        }
        return this;
    }

    public MobileStatusSubject Add(MobileStatusType[] types, int value)
    {
        foreach (var type in types)
        {
            Add(type, value);
        }
        return this;
    }

    public static MobileStatusSubject operator +(MobileStatusSubject x, MobileStatusSubject y) =>
        new()
        {
            Hp = x.Hp + y.Hp,
            BeamAttack = x.BeamAttack + y.BeamAttack,
            PhysicalAttack = x.PhysicalAttack + y.PhysicalAttack,
            BeamDefence = x.BeamDefence + y.BeamDefence,
            PhysicalDefence = x.PhysicalDefence + y.PhysicalDefence,
            CriticalRate = x.CriticalRate + y.CriticalRate,
            CriticalDamage = x.CriticalDamage + y.CriticalDamage,
            Accuracy = x.Accuracy + y.Accuracy,
            Evasion = x.Evasion + y.Evasion,
            Mobility = x.Mobility + y.Mobility,
            SuperEnRecovery = x.SuperEnRecovery + y.SuperEnRecovery,
            AceEnRecovery = x.AceEnRecovery + y.AceEnRecovery,
            SuperPower = x.SuperPower + y.SuperPower,
            AcePower = x.AcePower + y.AcePower,
            RecoveryPower = x.RecoveryPower + y.RecoveryPower,
        };

}
