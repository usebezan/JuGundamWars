using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Domain.Categories.Model;
using Ju.GundamWars.Domain.Grades.Model;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Serials.Dto;
using Ju.GundamWars.Domain.System;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Domain.Supports;

public partial class SupportSubject : SubjectBase
{

    public SupportSubject()
    {
        LimitedSerials = [];
        SlotBadges = new GwNotifiableCollection<SupportSlotBadgeSubject>().AddTo(Disposables);

        NormalStatus = new SupportStatusSubject().AddTo(Disposables);
        UnlockStatus = new SupportStatusSubject().AddTo(Disposables);
        BonusStatus = new SupportStatusSubject().AddTo(Disposables);
        ActualStatus = new SupportStatusSubject().AddTo(Disposables);

        LimitedSerials.CollectionChanged.Subscribe(WhenLimitedSerialsChanged).AddTo(Disposables);
        SlotBadges.CollectionChanged.Subscribe(WhenSlotBadgesChanged).AddTo(Disposables);
        SlotBadges.ItemPropertyChanged.Where(n => n == "Slot").Subscribe(WhenSlotChanged).AddTo(Disposables);
        SlotBadges.ItemPropertyChanged.Where(n => n == "Badge").Subscribe(WhenBadgeChanged).AddTo(Disposables);
        SlotBadges.ItemPropertyChanged.Where(n => n == "Status").Subscribe(WhenStatusChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Entity fields

    [ObservableProperty, Required]
    private string _Name = null!;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;
    [ObservableProperty]
    private bool _IsPinned;

    #endregion

    #region Entity relationships

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CategoryIcon))]
    private Category? _Category;
    [ObservableProperty, Required]
    private Serial? _Serial;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(GradeText)), NotifyPropertyChangedFor(nameof(GradeColor))]
    private Grade? _Grade;

    public GwObservableCollection<Serial> LimitedSerials { get; }
    public GwNotifiableCollection<SupportSlotBadgeSubject> SlotBadges { get; }

    #endregion

    #region Extensions

    public string CategoryIcon => Category?.Icon ?? GwIcon.Unknown;
    public string GradeText => Grade?.Name ?? string.Empty;
    public string GradeColor => Grade?.Color ?? "White";
    public bool HasMemo => !string.IsNullOrEmpty(Memo);

    [ObservableProperty]
    private int _AttachableSlotsCount;
    [ObservableProperty]
    private int _AttachedBadgesCount;
    [ObservableProperty]
    private string _LimitedSerialsText = null!;

    public SupportStatusSubject NormalStatus { get; }
    public SupportStatusSubject UnlockStatus { get; }
    public SupportStatusSubject BonusStatus { get; }
    public SupportStatusSubject ActualStatus { get; }

    #endregion

    [ObservableProperty]
    private MobileSubject? _Mobile;


    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedLimitedSerials();
        SetAttachableSlotsCount();
        SetAttachedBadgesCount();
        SetJoinedTags();
        CalculateActualStatus();
    }

    public void DetachAllBadges()
    {
        Suspend(() =>
        {
            foreach (var slotBadge in SlotBadges)
            {
                slotBadge.Badge = null;
            }
        });
        SetAttachedBadgesCount();
        CalculateActualStatus();
    }

    private void WhenLimitedSerialsChanged(NotifyCollectionChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetJoinedLimitedSerials();
    }

    private void WhenSlotBadgesChanged(NotifyCollectionChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetAttachableSlotsCount();
        SetAttachedBadgesCount();
        CalculateActualStatus();
    }

    private void WhenSlotChanged(string? _)
    {
        if (!IsIdle) return;
        SetAttachableSlotsCount();
    }

    private void WhenBadgeChanged(string? _)
    {
        if (!IsIdle) return;
        SetAttachedBadgesCount();
    }

    private void WhenStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
    }

    private void SetJoinedLimitedSerials() =>
        LimitedSerialsText = string.Join(", ", LimitedSerials.OrderBy(i => i.Order).Select(i => i.Name));

    private void SetAttachableSlotsCount() =>
        AttachableSlotsCount = SlotBadges.Where(s => s.Slot?.IsAttachable ?? false).Count();

    private void SetAttachedBadgesCount() =>
        AttachedBadgesCount = SlotBadges.Where(s => (s.Slot?.IsAttachable ?? false) && s.Badge != null).Count();

    private void CalculateActualStatus()
    {
        NormalStatus.Reset();
        UnlockStatus.Reset();
        BonusStatus.Reset();
        ActualStatus.Reset();
        if (!SlotBadges.All(s => s.Badge == null))
        {
            foreach (var slotBadge in SlotBadges)
            {
                var slotKind = slotBadge.Slot?.Kind ?? SupportSlotKindType.Unknown;
                if (slotKind == SupportSlotKindType.Normal)
                {
                    NormalStatus.Add(slotBadge.SupportStatusType, slotBadge.StatusValue);
                }
                else if (slotKind == SupportSlotKindType.Unlock)
                {
                    UnlockStatus.Add(slotBadge.SupportStatusType, slotBadge.StatusValue);
                }
                else if (slotKind == SupportSlotKindType.Bonus)
                {
                    BonusStatus.Add(slotBadge.SupportStatusType, slotBadge.StatusValue);
                }
            }
            ActualStatus.Set(NormalStatus).Add(UnlockStatus).Add(BonusStatus);
        }
        RaiseMobileBoostChanged();
    }

}
