using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Biz._.Mobiles.Domain;
using Ju.GundamWars.BizMaster._.Categories.Domain;
using Ju.GundamWars.BizMaster.Grades.Domain.Model;
using Ju.GundamWars.BizMaster.Serials.Domain.Model;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizMaster.Units;
using Ju.GundamWars.Collections;
using Ju.GundamWars.Commons.Domain.Model;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.Biz.Supports.Domain.Model;

public partial class Support : BizBase, ISupport
{

    public Support()
    {
        LimitedSerials = [];
        SlotBadges = new ObservableItemPropertyChangedCollection<SupportSlotBadge>().AddTo(Disposables);

        NormalStatus = new SupportStatus().AddTo(Disposables);
        UnlockStatus = new SupportStatus().AddTo(Disposables);
        BonusStatus = new SupportStatus().AddTo(Disposables);
        ActualStatus = new SupportStatus().AddTo(Disposables);

        LimitedSerials.CollectionChanged.Subscribe(WhenLimitedSerialsChanged).AddTo(Disposables);
        SlotBadges.CollectionChanged.Subscribe(WhenSlotBadgesChanged).AddTo(Disposables);
        SlotBadges.ItemPropertyChanged.Where(e => e.PropertyName == "Slot").Subscribe(WhenSlotChanged).AddTo(Disposables);
        SlotBadges.ItemPropertyChanged.Where(e => e.PropertyName == "Badge").Subscribe(WhenBadgeChanged).AddTo(Disposables);
        SlotBadges.ItemPropertyChanged.Where(e => e.PropertyName == "Status").Subscribe(WhenStatusChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty, Required]
    private string _Name = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(UnitIcon))]
    private UnitType _ForUnit = UnitType.MobileSuit;
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

    #endregion

    #region Navigations

    public MasterObservableCollection<Serial> LimitedSerials { get; }
    public ObservableItemPropertyChangedCollection<SupportSlotBadge> SlotBadges { get; }

    #endregion

    #region Extensions

    public string UnitIcon => ForUnit.ToIcon();
    public bool HasMemo => !string.IsNullOrEmpty(Memo);
    public string GradeText => Grade?.Name ?? "?";
    public string GradeColor => Grade?.Color ?? "White";

    #endregion

    [ObservableProperty]
    private string _LimitedSerialsText = string.Empty;
    [ObservableProperty]
    private int _AttachableSlotsCount;
    [ObservableProperty]
    private int _AttachedBadgesCount;

    public SupportStatus NormalStatus { get; }
    public SupportStatus UnlockStatus { get; }
    public SupportStatus BonusStatus { get; }
    public SupportStatus ActualStatus { get; }

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

    private void WhenSlotChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetAttachableSlotsCount();
    }

    private void WhenBadgeChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetAttachedBadgesCount();
    }

    private void WhenStatusChanged(PropertyChangedEventArgs _)
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
