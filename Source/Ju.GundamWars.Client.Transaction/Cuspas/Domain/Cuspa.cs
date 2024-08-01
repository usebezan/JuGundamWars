using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.CuspaKinds.Domain;
using Ju.GundamWars.Share.Cuspas;
using Ju.GundamWars.Share.Cuspas.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.Cuspas.Domain;

public partial class Cuspa : BizBase, ICuspa<CuspaStatus>
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

    [ObservableProperty, NotifyPropertyChangedFor(nameof(ForUnitIcon)), NotifyPropertyChangedFor(nameof(ForUnitText))]
    private UnitType _ForUnitType = UnitType.MobileSuit;
    [ObservableProperty]
    private CuspaKindType _CuspaKindType;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty]
    private BoostStatusType _BoostStatusType;
    [ObservableProperty]
    private int _BasicValue;

    #endregion

    #region Primitive Models

    [ObservableProperty, NotifyPropertyChangedFor(nameof(Name))]
    private CuspaKind? _CuspaKind;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(Name))]
    private BoostStatus? _BoostStatus;

    public CuspaStatus BasicStatus { get; }
    public CuspaStatus BonusStatus { get; }

    #endregion

    #region Extensions

    public string ForUnitIcon => ForUnitType.ToIcon();
    public string ForUnitText => ForUnitType.ToText();
    public string Name => $"{BoostStatusType.ToText()}{CuspaKindType.ToSurffix()} {BasicValue}/{BonusStatus.ToText()}";

    public CuspaStatus ActualStatus { get; }

    #endregion


    partial void OnBasicValueChanged(int value) =>
        BasicStatus.Reset(BoostStatus?.Type ?? BoostStatusType.Unknown, BasicValue);

    partial void OnCuspaKindChanged(CuspaKind? value) =>
        CuspaKindType = CuspaKind?.Type ?? CuspaKindType.Unknown;

    partial void OnBoostStatusChanged(BoostStatus? value)
    {
        var type = BoostStatus?.Type ?? BoostStatusType.Unknown;
        BoostStatusType = type;
        BasicStatus.Reset(type, BasicValue);
    }

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

    public Cuspa Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        OnPropertyChanged(nameof(HasMemo));
        CalculateActualStatus();
        RaiseMobileBoostChanged();
        return this;
    }

}
