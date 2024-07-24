using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Share.Roles.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.CoMobiles.Domain;

public partial class CoMobile : BizBase
{

    public CoMobile()
    {
        BasicStatus = new CoMobileStatus().AddTo(Disposables);
        UpgradedStatus = new CoMobileStatus().AddTo(Disposables);
        UpgradedCount = new CoMobileUpgradedCount().AddTo(Disposables);
        ActualStatus = new CoMobileStatus().AddTo(Disposables);
        UpgradedDefaultStatus = new CoMobileStatus().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        UpgradedStatus.PropertyChanged.Subscribe(WhenUpgradedStatusChanged).AddTo(Disposables);
        UpgradedCount.PropertyChanged.Subscribe(WhenUpgradedCountChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty, Required]
    private string _Name = string.Empty;
    [ObservableProperty, Required]
    private byte _Level;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;
    [ObservableProperty]
    private bool _IsPinned;

    #endregion

    #region Primitive Models

    [ObservableProperty, Required]
    private Serial? _Serial;
    [ObservableProperty, Required]
    private Role? _Role;

    public CoMobileStatus BasicStatus { get; }
    public CoMobileStatus UpgradedStatus { get; }
    public CoMobileUpgradedCount UpgradedCount { get; }

    #endregion

    #region Extensions

    public bool HasMemo => !string.IsNullOrEmpty(Memo);

    [ObservableProperty]
    private int _UpgradedCountTotal;

    public CoMobileStatus ActualStatus { get; }
    public CoMobileStatus UpgradedDefaultStatus { get; }

    #endregion

    // TODO:
    //[ObservableProperty]
    //private MobileSubject? _Mobile;


    public CoMobile Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        OnPropertyChanged(nameof(Memo));
        SetUpgradedCountTotal();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
        return this;
    }

    public void ResetUpgraded()
    {
        Suspend(() =>
        {
            UpgradedStatus.Reset();
            UpgradedDefaultStatus.Reset();
            UpgradedCount.Reset();
        });
        SetUpgradedCountTotal();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenBasicStatusChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenUpgradedStatusChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenUpgradedCountChanged(PropertyChangedEventArgs e)
    {
        if (!IsIdle) return;
        SetUpgradedCountTotal();
        // set default
        // FIXME: magic number
        switch (e.PropertyName)
        {
            case "Hp":
                UpgradedStatus.Hp = 10000 * UpgradedCount.Hp;
                UpgradedDefaultStatus.Hp = UpgradedStatus.Hp;
                break;
            case "BeamAttack":
                UpgradedStatus.BeamAttack = 200 * UpgradedCount.BeamAttack;
                UpgradedDefaultStatus.BeamAttack = UpgradedStatus.BeamAttack;
                break;
            case "PhysicalAttack":
                UpgradedStatus.PhysicalAttack = 200 * UpgradedCount.PhysicalAttack;
                UpgradedDefaultStatus.PhysicalAttack = UpgradedStatus.PhysicalAttack;
                break;
            case "BeamDefence":
                UpgradedStatus.BeamDefence = 400 * UpgradedCount.BeamDefence;
                UpgradedDefaultStatus.BeamDefence = UpgradedStatus.BeamDefence;
                break;
            case "PhysicalDefence":
                UpgradedStatus.PhysicalDefence = 400 * UpgradedCount.PhysicalDefence;
                UpgradedDefaultStatus.PhysicalDefence = UpgradedStatus.PhysicalDefence;
                break;
            case "CriticalDamage":
                UpgradedStatus.CriticalDamage = 10 * UpgradedCount.CriticalDamage;
                UpgradedDefaultStatus.CriticalDamage = UpgradedStatus.CriticalDamage;
                break;
            case "Accuracy":
                UpgradedStatus.Accuracy = 60 * UpgradedCount.Accuracy;
                UpgradedDefaultStatus.Accuracy = UpgradedStatus.Accuracy;
                break;
            case "Evasion":
                UpgradedStatus.Evasion = 50 * UpgradedCount.Evasion;
                UpgradedDefaultStatus.Evasion = UpgradedStatus.Evasion;
                break;
            case "Mobility":
                UpgradedStatus.Mobility = 80 * UpgradedCount.Mobility;
                UpgradedDefaultStatus.Mobility = UpgradedStatus.Mobility;
                break;
        }
    }

    private void SetUpgradedCountTotal() =>
        UpgradedCountTotal = UpgradedCount.Total;

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(UpgradedStatus);

}
