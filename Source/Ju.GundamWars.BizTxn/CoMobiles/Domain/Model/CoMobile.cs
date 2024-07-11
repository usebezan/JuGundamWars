using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizConst.Roles.Domain;
using Ju.GundamWars.BizMaster.Serials.Domain;
using Ju.GundamWars.BizTxn.Commons.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.BizTxn.CoMobiles.Domain.Model;

public partial class CoMobile : BizBase, ICoMobile
{

    public CoMobile()
    {
        BasicStatus = new CoMobileStatus().AddTo(Disposables);
        UpgradedStatus = new CoMobileStatus().AddTo(Disposables);
        UpgradedCount = new CoMobileUpgradedCount().AddTo(Disposables);
        ActualStatus = new CoMobileStatus().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        UpgradedStatus.PropertyChanged.Subscribe(WhenUpgradedStatusChanged).AddTo(Disposables);
        UpgradedCount.PropertyChanged.Subscribe(WhenUpgradedCountChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty, Required]
    private string _Name = null!;
    [ObservableProperty]
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

    #endregion

    // TODO:
    //[ObservableProperty]
    //private MobileSubject? _Mobile;


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
