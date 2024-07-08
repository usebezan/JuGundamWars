using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.System;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Domain.Cuspas;

public partial class CuspaSubject : SubjectBase
{

    public CuspaSubject()
    {
        BasicStatus = new CuspaStatusSubject().AddTo(Disposables);
        BonusStatus = new CuspaStatusSubject().AddTo(Disposables);
        ActualStatus = new CuspaStatusSubject().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        BonusStatus.PropertyChanged.Subscribe(WhenBonusStatusChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Entity fields

    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(Name))]
    private string _SubName = null!;
    [ObservableProperty]
    private byte _Level;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;

    public CuspaStatusSubject BasicStatus { get; }
    public CuspaStatusSubject BonusStatus { get; }

    #endregion

    #region Entity relationships

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CategoryIcon))]
    private Category? _Category;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(KindName))]
    private CuspaKind? _Kind;

    #endregion

    #region Extensions

    public string CategoryIcon => Category?.Icon ?? GwIcon.Unknown;
    public string KindName => Kind?.Name ?? GwText.Unknown;
    public string Name => $"{KindName}{SubName}";
    public bool HasMemo => !string.IsNullOrEmpty(Memo);

    public CuspaStatusSubject ActualStatus { get; }

    #endregion

    [ObservableProperty]
    private bool _IsPinned = true;


    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenBasicStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void WhenBonusStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
        RaiseMobileBoostChanged();
    }

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(BonusStatus);

}
