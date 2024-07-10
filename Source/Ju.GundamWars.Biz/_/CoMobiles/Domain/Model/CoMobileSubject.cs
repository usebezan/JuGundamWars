using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars;
using Ju.GundamWars.Biz._.Mobiles.Domain;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Roles.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Serials.Dto;
using Ju.GundamWars.Core.Ju.GundamWars.System;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Biz._.CoMobiles.Domain.Model;

public partial class CoMobileSubject : SubjectBase
{

    public CoMobileSubject()
    {
        BasicStatus = new CoMobileStatusSubject().AddTo(Disposables);
        UpgradedStatus = new CoMobileStatusSubject().AddTo(Disposables);
        UpgradedCount = new CoMobileUpgradedCountSubject().AddTo(Disposables);
        ActualStatus = new CoMobileStatusSubject().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        UpgradedStatus.PropertyChanged.Subscribe(WhenUpgradedStatusChanged).AddTo(Disposables);
        UpgradedCount.PropertyChanged.Subscribe(WhenUpgradedCountChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Entity fields

    [ObservableProperty, Required]
    private string _Name = null!;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;
    [ObservableProperty]
    private bool _IsPinned;

    public CoMobileStatusSubject BasicStatus { get; }
    public CoMobileStatusSubject UpgradedStatus { get; }
    public CoMobileUpgradedCountSubject UpgradedCount { get; }

    #endregion

    #region Entity relationships

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CategoryIcon))]
    private Category? _Category;
    [ObservableProperty, Required]
    private Serial? _Serial;
    [ObservableProperty, Required]
    private Role? _Role;

    #endregion

    #region Extensions

    public string CategoryIcon => Category?.Icon ?? GwIcon.Unknown;
    public bool HasMemo => !string.IsNullOrEmpty(Memo);

    [ObservableProperty]
    private int _UpgradedCountTotal;

    public CoMobileStatusSubject ActualStatus { get; }

    #endregion

    [ObservableProperty]
    private MobileSubject? _Mobile;


    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        SetUpgradedCountTotal();
        SetJoinedTags();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    public void ResetUpgraded()
    {
        Suspend(() =>
        {
            UpgradedStatus.Reset();
            UpgradedCount.Reset();
        });
        SetUpgradedCountTotal();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenBasicStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenUpgradedStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenUpgradedCountChanged(string? propertyName)
    {
        if (!IsIdle) return;
        SetUpgradedCountTotal();
        // set default
        // FIXME: magic number
        switch (propertyName)
        {
            case "Hp":
                UpgradedStatus.Hp = 10000 * UpgradedCount.Hp;
                break;
            case "BeamAttack":
                UpgradedStatus.BeamAttack = 200 * UpgradedCount.BeamAttack;
                break;
            case "PhysicalAttack":
                UpgradedStatus.PhysicalAttack = 200 * UpgradedCount.PhysicalAttack;
                break;
            case "BeamDefence":
                UpgradedStatus.BeamDefence = 400 * UpgradedCount.BeamDefence;
                break;
            case "PhysicalDefence":
                UpgradedStatus.PhysicalDefence = 400 * UpgradedCount.PhysicalDefence;
                break;
            case "CriticalDamage":
                UpgradedStatus.CriticalDamage = 10 * UpgradedCount.CriticalDamage;
                break;
            case "Accuracy":
                UpgradedStatus.Accuracy = 60 * UpgradedCount.Accuracy;
                break;
            case "Evasion":
                UpgradedStatus.Evasion = 50 * UpgradedCount.Evasion;
                break;
            case "Mobility":
                UpgradedStatus.Mobility = 80 * UpgradedCount.Mobility;
                break;
        }
    }

    private void SetUpgradedCountTotal() =>
        UpgradedCountTotal = UpgradedCount.Total();

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(UpgradedStatus);

}
