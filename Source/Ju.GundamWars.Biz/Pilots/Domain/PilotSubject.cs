using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Core;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Boosts;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Grades.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Serials.Dto;
using Ju.GundamWars.Core.Ju.GundamWars.System;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Pilots.Domain;
using Ju.GundamWars.Pilots.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Pilots.Domain;

public partial class PilotSubject : SubjectBase
{

    public PilotSubject()
    {
        BasicStatus = new PilotStatusSubject().AddTo(Disposables);
        PracticedStatus = new PilotStatusSubject().AddTo(Disposables);
        AbilityStatus = new PilotStatusSubject().AddTo(Disposables);
        ActualStatus = new PilotStatusSubject().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        PracticedStatus.PropertyChanged.Subscribe(WhenPracticedStatusChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Entity fields

    [ObservableProperty, Required]
    private string _Name = null!;
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

    public PilotStatusSubject BasicStatus { get; }
    public PilotStatusSubject PracticedStatus { get; }

    #endregion

    #region Entity relationships

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CategoryIcon))]
    private Category? _Category;
    [ObservableProperty, Required]
    private Serial? _Serial;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(GradeText)), NotifyPropertyChangedFor(nameof(GradeColor))]
    private Grade? _Grade;
    [ObservableProperty, Required]
    private PilotSkill? _Skill;
    [ObservableProperty]
    private PilotAbility? _Ability1;
    [ObservableProperty]
    private PilotAbility? _Ability2;
    [ObservableProperty]
    private PilotAbility? _Ability3;

    #endregion

    #region Extensions

    public string CategoryIcon => Category?.Icon ?? GwIcon.Unknown;
    public string GradeText => Grade?.Name ?? string.Empty;
    public string GradeColor => Grade?.Color ?? "White";
    public bool HasMemo => !string.IsNullOrEmpty(Memo);

    [ObservableProperty]
    private int _PracticedStatusTotal;

    public PilotStatusSubject AbilityStatus { get; }
    public PilotStatusSubject ActualStatus { get; }

    #endregion

    [ObservableProperty]
    private MobileSubject? _Mobile;

    public List<PilotAbility> AbilitiesForMobile => new[] { Ability1, Ability2, Ability3 }.Where(i => i != null && i.BoostCategory == BoostUnitType.Mobile).Select(i => i!).ToList();


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

    private void WhenBasicStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
    }

    private void WhenPracticedStatusChanged(string? _)
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
        if (ability != null && ability.BoostCategory == BoostUnitType.Pilot)
        {
            AbilityStatus.Add(ability.Boost.ToPilotStatusType(), ability.Value);
        }
    }

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(PracticedStatus).Add(AbilityStatus);

}
