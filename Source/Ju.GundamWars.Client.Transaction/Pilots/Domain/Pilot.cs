using CommunityToolkit.Mvvm.ComponentModel;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.PilotSkills.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Pilots;
using Ju.GundamWars.Share.Pilots.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.Pilots.Domain;

public partial class Pilot : BizBase, IPilot<PilotStatus>
{

    public Pilot()
    {
        BasicStatus = new PilotStatus().AddTo(Disposables);
        PracticedStatus = new PilotStatus().AddTo(Disposables);
        AbilityStatus = new PilotStatus().AddTo(Disposables);
        ActualStatus = new PilotStatus().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        PracticedStatus.PropertyChanged.Subscribe(WhenPracticedStatusChanged).AddTo(Disposables);
        PilotSlotAbilities.ItemPropertyChanged.Where(e => e.PropertyName == "Ability").Subscribe(WhenAbilityChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty]
    private string _Name = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(ForUnitIcon)), NotifyPropertyChangedFor(nameof(ForUnitText))]
    private UnitType _ForUnitType = UnitType.MobileSuit;
    [ObservableProperty]
    private int _SerialId;
    [ObservableProperty]
    private GradeType _GradeType;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty]
    private int _PilotSkillId;
    [ObservableProperty]
    private string? _PilotSkillText1;
    [ObservableProperty]
    private string? _PilotSkillText2;
    [ObservableProperty]
    private bool _IsPinned;

    #endregion

    #region Primitive Models

    [ObservableProperty]
    private Serial? _Serial;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(GradeText)), NotifyPropertyChangedFor(nameof(GradeColor))]
    private Grade? _Grade;
    [ObservableProperty]
    private PilotSkill? _PilotSkill;

    public PilotStatus BasicStatus { get; }
    public PilotStatus PracticedStatus { get; }

    #endregion

    #region Navigations

    public ObservableItemPropertyChangedCollection<PilotSlotAbility> PilotSlotAbilities { get; } = [];

    #endregion

    #region Extensions

    public string ForUnitIcon => ForUnitType.ToIcon();
    public string ForUnitText => ForUnitType.ToText();
    public string GradeText => GradeType.ToText();
    public string GradeColor => GradeType.ToColor();

    [ObservableProperty]
    private int _PracticedStatusTotal;

    public PilotStatus AbilityStatus { get; }
    public PilotStatus ActualStatus { get; }

    #endregion

    // TODO:
    //[ObservableProperty]
    //private MobileSubject? _Mobile;


    partial void OnSerialChanged(Serial? value) =>
        SerialId = value?.Id ?? 0;

    partial void OnGradeChanged(Grade? value) =>
        GradeType = value?.Type ?? GradeType.Unknown;

    partial void OnPilotSkillChanged(PilotSkill? value) =>
        PilotSkillId = value?.Id ?? 0;

    private void WhenBasicStatusChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
    }

    private void WhenPracticedStatusChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetPracticedStatusTotal();
        CalculateActualStatus();
    }

    private void WhenAbilityChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        CalculateAbilityStatus();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void SetPracticedStatusTotal() =>
        PracticedStatusTotal = PracticedStatus.Total;

    private void CalculateAbilityStatus()
    {
        AbilityStatus.Reset();
        foreach (var ability in PilotSlotAbilities.Where(m => m.PilotAbility != null && m.PilotAbility.BoostCategoryType == BoostCategoryType.Pilot).Select(m => m.PilotAbility!))
        {
            // パイロットは加算のみ
            AbilityStatus.Add(ability.BoostStatusType, ability.Value);
        }
    }

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(PracticedStatus).Add(AbilityStatus);

    public Pilot Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        OnPropertyChanged(nameof(HasMemo));
        SetPracticedStatusTotal();
        CalculateAbilityStatus();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
        return this;
    }

    public void ResetPracticed()
    {
        Suspend(() => PracticedStatus.Reset());
        SetPracticedStatusTotal();
        CalculateActualStatus();
    }

}
