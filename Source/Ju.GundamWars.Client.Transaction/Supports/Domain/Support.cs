using CommunityToolkit.Mvvm.ComponentModel;
using Ju.Collections.ObjectModel;
using Ju.GundamWars.Client.Commons.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Supports.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;
using Ju.GundamWars.Share.Units.Domain;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Ju.GundamWars.Client.Supports.Domain;

public partial class Support : BizBase, ISupport
{

    public Support()
    {
        SupportLimitedSerials = [];
        SupportSlotBadges = new ObservableItemPropertyChangedCollection<SupportSlotBadge>().AddTo(Disposables);

        NormalStatus = new SupportStatus().AddTo(Disposables);
        UnlockStatus = new SupportStatus().AddTo(Disposables);
        BonusStatus = new SupportStatus().AddTo(Disposables);
        ActualStatus = new SupportStatus().AddTo(Disposables);

        SupportLimitedSerials.CollectionChanged.Subscribe(WhenLimitedSerialsChanged).AddTo(Disposables);
        SupportSlotBadges.CollectionChanged.Subscribe(WhenSlotBadgesChanged).AddTo(Disposables);
        SupportSlotBadges.ItemPropertyChanged.Where(e => e.PropertyName == "Slot").Subscribe(WhenSlotChanged).AddTo(Disposables);
        SupportSlotBadges.ItemPropertyChanged.Where(e => e.PropertyName == "Badge").Subscribe(WhenBadgeChanged).AddTo(Disposables);
        SupportSlotBadges.ItemPropertyChanged.Where(e => e.PropertyName == "SlotBadge").Subscribe(WhenSlotBadgeChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Primitives

    [ObservableProperty]
    private string _Name = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(ForUnitIcon)), NotifyPropertyChangedFor(nameof(ForUnitText))]
    private UnitType _ForUnitType = UnitType.MobileSuit;
    [ObservableProperty]
    private int _SerialId;
    [ObservableProperty]
    private GradeType _GradeType;
    [ObservableProperty]
    private bool _IsPinned;

    #endregion

    #region Primitive Models

    [ObservableProperty]
    private Serial? _Serial;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(GradeText)), NotifyPropertyChangedFor(nameof(GradeColor))]
    private Grade? _Grade;

    #endregion

    #region Navigations

    public MasterInventory<Serial> SupportLimitedSerials { get; }
    public ObservableItemPropertyChangedCollection<SupportSlotBadge> SupportSlotBadges { get; }

    #endregion

    #region Extensions

    public string ForUnitIcon => ForUnitType.ToIcon();
    public string ForUnitText => ForUnitType.ToText();
    public string GradeText => GradeType.ToText();
    public string GradeColor => GradeType.ToColor();

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

    #endregion

    // TODO:
    //[ObservableProperty]
    //private MobileSubject? _Mobile;


    partial void OnSerialChanged(Serial? value) =>
        SerialId = value?.Id ?? 0;

    partial void OnGradeChanged(Grade? value) =>
        GradeType = value?.Type ?? GradeType.Unknown;

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

    private void WhenSlotBadgeChanged(PropertyChangedEventArgs _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
    }

    private void SetJoinedLimitedSerials() =>
        LimitedSerialsText = string.Join(", ", SupportLimitedSerials.OrderBy(i => i.Order).Select(i => i.Name));

    private void SetAttachableSlotsCount() =>
        AttachableSlotsCount = SupportSlotBadges.Where(s => s.SupportSlot?.IsAttachable ?? false).Count();

    private void SetAttachedBadgesCount() =>
        AttachedBadgesCount = SupportSlotBadges.Where(s => (s.SupportSlot?.IsAttachable ?? false) && s.SupportBadge != null).Count();

    private void CalculateActualStatus()
    {
        NormalStatus.Reset();
        UnlockStatus.Reset();
        BonusStatus.Reset();
        ActualStatus.Reset();
        if (!SupportSlotBadges.All(s => s.SupportBadge == null))
        {
            foreach (var slotBadge in SupportSlotBadges)
            {
                var slotKind = slotBadge.SupportSlot?.SupportSlotKindType ?? SupportSlotKindType.Unknown;
                if (slotKind == SupportSlotKindType.Normal)
                {
                    NormalStatus.Add(slotBadge.BoostStatusType, slotBadge.StatusValue);
                }
                else if (slotKind == SupportSlotKindType.Unlock)
                {
                    UnlockStatus.Add(slotBadge.BoostStatusType, slotBadge.StatusValue);
                }
                else if (slotKind == SupportSlotKindType.Bonus)
                {
                    BonusStatus.Add(slotBadge.BoostStatusType, slotBadge.StatusValue);
                }
            }
            ActualStatus.Set(NormalStatus).Add(UnlockStatus).Add(BonusStatus);
        }
        RaiseMobileBoostChanged();
    }

    public Support Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedTags();
        OnPropertyChanged(nameof(HasMemo));
        SetJoinedLimitedSerials();
        SetAttachableSlotsCount();
        SetAttachedBadgesCount();
        CalculateActualStatus();
        return this;
    }

    public void DetachAllBadges()
    {
        Suspend(() =>
        {
            foreach (var slotBadge in SupportSlotBadges)
            {
                slotBadge.SupportBadge = null;
            }
        });
        SetAttachedBadgesCount();
        CalculateActualStatus();
    }

}
