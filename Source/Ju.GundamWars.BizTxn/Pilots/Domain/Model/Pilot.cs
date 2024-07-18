using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.BizConst.Units.Domain;
using Ju.GundamWars.BizMaster.PilotAbilities.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizMaster.Skills.Domain;
using Ju.GundamWars.BizTxn.Commons.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Model;

public partial class Pilot : BizBase, IPilot
{

    public Pilot()
    {
        BasicStatus = new PilotStatus().AddTo(Disposables);
        PracticedStatus = new PilotStatus().AddTo(Disposables);
        AbilityStatus = new PilotStatus().AddTo(Disposables);
        ActualStatus = new PilotStatus().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        PracticedStatus.PropertyChanged.Subscribe(WhenPracticedStatusChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty, Required]
    private string _Name = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(UnitIcon))]
    private UnitType _ForUnit = UnitType.MobileSuit;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty]
    private string? _SkillText1;
    [ObservableProperty]
    private string? _SkillText2;
    [ObservableProperty]
    private int _SlotRank1;
    [ObservableProperty]
    private int _SlotRank2;
    [ObservableProperty]
    private int _SlotRank3;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;
    [ObservableProperty]
    private bool _IsPinned;

    #endregion

    #region Primitive Models

    [ObservableProperty, Required]
    private Serial? _Serial;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(GradeText)), NotifyPropertyChangedFor(nameof(GradeColor))]
    private Grade? _Grade;
    [ObservableProperty, Required]
    private Skill? _Skill;
    [ObservableProperty]
    private PilotAbility? _Ability1;
    [ObservableProperty]
    private PilotAbility? _Ability2;
    [ObservableProperty]
    private PilotAbility? _Ability3;

    public PilotStatus BasicStatus { get; }
    public PilotStatus PracticedStatus { get; }

    #endregion

    #region Extensions

    public string UnitIcon => ForUnit.ToIcon();
    public bool HasMemo => !string.IsNullOrEmpty(Memo);
    public string GradeText => Grade?.Name ?? "?";
    public string GradeColor => Grade?.Color ?? "White";

    [ObservableProperty]
    private int _PracticedStatusTotal;

    public PilotStatus AbilityStatus { get; }
    public PilotStatus ActualStatus { get; }

    public List<PilotAbility> AbilitiesForMobile => new[] { Ability1, Ability2, Ability3 }.Where(a => a != null && a.BoostCategory == BoostCategoryType.Mobile).Select(a => a!).ToList();

    #endregion

    // TODO:
    //[ObservableProperty]
    //private MobileSubject? _Mobile;


    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        SetPracticedStatusTotal();
        SetJoinedTags();
        CalculateAbilityStatus();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    public void ResetPracticed()
    {
        Suspend(() => PracticedStatus.Reset());
        SetPracticedStatusTotal();
        CalculateActualStatus();
    }

    partial void OnAbility1Changed(PilotAbility? value)
    {
        if (!IsIdle) return;
        CalculateAbilityStatus();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    partial void OnAbility2Changed(PilotAbility? value)
    {
        if (!IsIdle) return;
        CalculateAbilityStatus();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    partial void OnAbility3Changed(PilotAbility? value)
    {
        if (!IsIdle) return;
        CalculateAbilityStatus();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

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

    private void SetPracticedStatusTotal() =>
        PracticedStatusTotal = PracticedStatus.Total();

    private void CalculateAbilityStatus()
    {
        AbilityStatus.Reset();
        CalculateAbilityStatus(Ability1);
        CalculateAbilityStatus(Ability2);
        CalculateAbilityStatus(Ability3);
    }

    // パイロットは加算のみ
    private void CalculateAbilityStatus(PilotAbility? ability)
    {
        if (ability != null && ability.BoostCategory == BoostCategoryType.Pilot)
        {
            AbilityStatus.Add(ability.BoostStatus, ability.Value);
        }
    }

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(PracticedStatus).Add(AbilityStatus);

}
