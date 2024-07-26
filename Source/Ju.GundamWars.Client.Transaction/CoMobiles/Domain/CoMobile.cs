using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Share.CoMobiles;
using Ju.GundamWars.Share.CoMobiles.Domain;
using Ju.GundamWars.Share.Roles.Domain;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.CoMobiles.Domain;

public partial class CoMobile : BizBase, ICoMobile<CoMobileStatus, CoMobileUpgradedCount>
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

    [ObservableProperty]
    private string _Name = string.Empty;
    [ObservableProperty]
    private int _SerialId;
    [ObservableProperty]
    private RoleType _RoleType;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty]
    private bool _IsPinned;

    #endregion

    #region Primitive Models

    [ObservableProperty]
    private Serial? _Serial;
    [ObservableProperty]
    private Role? _Role;

    public CoMobileStatus BasicStatus { get; }
    public CoMobileStatus UpgradedStatus { get; }
    public CoMobileUpgradedCount UpgradedCount { get; }

    #endregion

    #region Extensions

    [ObservableProperty]
    private int _UpgradedCountTotal;

    public CoMobileStatus ActualStatus { get; }
    public CoMobileStatus UpgradedDefaultStatus { get; }

    #endregion

    // TODO:
    //[ObservableProperty]
    //private MobileSubject? _Mobile;


    partial void OnSerialChanged(Serial? value) =>
        SerialId = Serial?.Id ?? 0;

    partial void OnRoleChanged(Role? value) =>
        RoleType = Role?.Type ?? RoleType.Unknown;

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

    // NOTE: ActualStatus の計算は UpgradedStatus に値を設定したイベントで実行される
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

    public CoMobile Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        OnPropertyChanged(nameof(HasMemo));
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
            UpgradedCount.Reset();
            UpgradedDefaultStatus.Reset();
        });
        SetUpgradedCountTotal();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

}
