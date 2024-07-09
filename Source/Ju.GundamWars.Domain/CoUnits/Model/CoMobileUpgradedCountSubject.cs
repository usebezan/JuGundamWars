using CommunityToolkit.Mvvm.ComponentModel;

namespace Ju.GundamWars.Domain.CoUnits.Model;

public partial class CoUnitUpgradedCountSubject : GwObservableObject
{

    [ObservableProperty, NotifyPropertyChangedFor(nameof(HpText))]
    private int _Hp;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BeamAttackText))]
    private int _BeamAttack;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(PhysicalAttackText))]
    private int _PhysicalAttack;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BeamDefenceText))]
    private int _BeamDefence;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(PhysicalDefenceText))]
    private int _PhysicalDefence;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(CriticalDamageText))]
    private int _CriticalDamage;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(AccuracyText))]
    private int _Accuracy;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(EvasionText))]
    private int _Evasion;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(MobilityText))]
    private int _Mobility;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(StartupText))]
    private int _Startup;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(SuperMoveText))]
    private int _SuperMove;

    public string HpText => GetText(Hp);
    public string BeamAttackText => GetText(BeamAttack);
    public string PhysicalAttackText => GetText(PhysicalAttack);
    public string BeamDefenceText => GetText(BeamDefence);
    public string PhysicalDefenceText => GetText(PhysicalDefence);
    public string CriticalDamageText => GetText(CriticalDamage);
    public string AccuracyText => GetText(Accuracy);
    public string EvasionText => GetText(Evasion);
    public string MobilityText => GetText(Mobility);
    public string StartupText => GetText(Startup);
    public string SuperMoveText => GetText(SuperMove);


    public CoUnitUpgradedCountSubject Reset()
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
        Startup = 0;
        SuperMove = 0;
        return this;
    }

    public CoUnitUpgradedCountSubject Set(CoUnitUpgradedCountSubject status)
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
        Startup = status.Startup;
        SuperMove = status.SuperMove;
        return this;
    }

    public int Total() =>
        Hp + BeamAttack + PhysicalAttack + BeamDefence + PhysicalDefence + CriticalDamage + Accuracy + Evasion + Mobility + Startup + SuperMove;

    private string GetText(int value) =>
        "".PadLeft(value, '■').PadRight(5, '□')[..5];

}
