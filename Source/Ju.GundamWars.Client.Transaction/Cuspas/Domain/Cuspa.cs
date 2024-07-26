using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.Cuspas.Domain;

public partial class Cuspa : BizBase
{

    public Cuspa()
    {
        BasicStatus = new CuspaStatus().AddTo(Disposables);
        BonusStatus = new CuspaStatus().AddTo(Disposables);
        ActualStatus = new CuspaStatus().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        BonusStatus.PropertyChanged.Subscribe(WhenBonusStatusChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty, NotifyPropertyChangedFor(nameof(ForUnitIcon))]
    private UnitType _ForUnitType = UnitType.MobileSuit;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty]
    private int _BasicValue;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;

    #endregion

    #region Primitive Models

    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(Name))]
    private CuspaKind? _CuspaKind;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(Name))]
    private BoostStatus? _BoostStatus;

    public CuspaStatus BasicStatus { get; }
    public CuspaStatus BonusStatus { get; }

    #endregion

    #region Extensions

    public string ForUnitIcon => ForUnitType.ToIcon();
    public bool HasMemo => !string.IsNullOrEmpty(Memo);
    public string Name => $"{BoostStatus?.Type.ToString()}{CuspaKind?.Type.ToSurffix()} {BasicStatus.ToText()}/{BonusStatus.ToText()}";

    public CuspaStatus ActualStatus { get; }

    #endregion


    public Cuspa Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
        return this;
    }

    partial void OnBasicValueChanged(int value) =>
        BasicStatus.Reset(BoostStatus?.Type ?? BoostStatusType.Unknown, BasicValue);

    partial void OnBoostStatusChanged(BoostStatus? value) =>
        BasicStatus.Reset(BoostStatus?.Type ?? BoostStatusType.Unknown, BasicValue);

    private void WhenBasicStatusChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        OnPropertyChanged(nameof(Name));
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenBonusStatusChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        OnPropertyChanged(nameof(Name));
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(BonusStatus);

}
