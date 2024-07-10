using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Core;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain;

public partial class MobileRemodeledStatusSubject : GwObservableObject
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


    public MobileRemodeledStatusSubject Reset()
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

    public MobileRemodeledStatusSubject Set(MobileRemodeledStatusSubject status)
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

    public MobileRemodeledStatusSubject Add(MobileRemodeledStatusSubject status)
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

}
