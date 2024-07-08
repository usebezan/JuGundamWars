using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Supports.Entities;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Supports;

public abstract partial class SupportListViewModelBase : GwObservableObject
{

    public SupportListViewModelBase(
        ISupportInventory supportInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory,
        IBoostInventory boostInventory,
        ISupportSlotInventory supportSlotInventory,
        ISupportBadgeInventory supportBadgeInventory)
    {
        ItemsView = new(supportInventory) { Filter = Filter, };
        Serials = new(serialInventory);
        Tags = new(tagInventory) { Filter = FilterTag, };
        UnlockSlots = new(boostInventory) { Filter = FilterUnlockSlot, };
        BonusSlots = new(boostInventory) { Filter = FilterBonusSlot, };
        Slots = new(supportSlotInventory);
        Badges = new(supportBadgeInventory);

        ItemsView.SortDescriptions.Add(new("Name", ListSortDirection.Ascending));
        ItemsView.SortDescriptions.Add(new("Id", ListSortDirection.Ascending));
        Slots.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
        Badges.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
    }


    protected bool IsIdle { get; set; } = false;

    public ListCollectionView ItemsView { get; }
    public ListCollectionView Serials { get; }
    public ListCollectionView Tags { get; }
    public ListCollectionView UnlockSlots { get; }
    public ListCollectionView BonusSlots { get; }
    public ListCollectionView Slots { get; }
    public ListCollectionView Badges { get; }

    [ObservableProperty]
    private Category? _Category;
    [ObservableProperty]
    private string _Word = string.Empty;
    [ObservableProperty]
    private bool _HasMemo = false;
    [ObservableProperty]
    private Serial? _Serial;
    [ObservableProperty]
    private Serial? _LimitedSerial;
    [ObservableProperty]
    private TagSubject? _Tag;
    [ObservableProperty]
    private Boost? _UnlockSlot;
    [ObservableProperty]
    private Boost? _BonusSlot;
    [ObservableProperty]
    private SupportSlot? _Slot;
    [ObservableProperty]
    private SupportBadge? _Badge;


    partial void OnCategoryChanged(Category? value) => Refresh();
    partial void OnWordChanged(string value) => Refresh();
    partial void OnHasMemoChanged(bool value) => Refresh();
    partial void OnSerialChanged(Serial? value) => Refresh();
    partial void OnLimitedSerialChanged(Serial? value) => Refresh();
    partial void OnTagChanged(TagSubject? value) => Refresh();
    partial void OnUnlockSlotChanged(Boost? value) => Refresh();
    partial void OnBonusSlotChanged(Boost? value) => Refresh();
    partial void OnSlotChanged(SupportSlot? value) => Refresh();
    partial void OnBadgeChanged(SupportBadge? value) => Refresh();

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        if (string.IsNullOrEmpty(item.Name)) return false;
        return item.KindType.ForSupport();
    }

    private bool FilterUnlockSlot(object obj)
    {
        if (obj is not Boost item) return false;
        return item.Type.ForMobile();
    }

    private bool FilterBonusSlot(object obj)
    {
        if (obj is not Boost item) return false;
        return item.Type.ForBadge();
    }

    protected abstract bool Filter(object obj);

    protected bool FilterCore(SupportSubject item)
    {
        if (Category != null && item.Category?.Type != Category.Type) return false;
        if (!string.IsNullOrEmpty(Word) &&
            !item.Name.Contains(Word) &&
            !(item.Memo ?? string.Empty).Contains(Word)) return false;
        if (HasMemo && !item.HasMemo) return false;
        if (Serial != null && item.Serial?.Id != Serial.Id) return false;
        if (LimitedSerial != null && !item.LimitedSerials.Any(s => s.Id == LimitedSerial.Id)) return false;
        if (Tag != null && !item.Tags.Any(s => s.Id == Tag.Id)) return false;
        if (UnlockSlot != null && !item.SlotBadges.Any(s => s.Slot?.Boost == UnlockSlot.Type)) return false;
        if (BonusSlot != null && !item.SlotBadges.Any(s => s.Slot?.Boost == BonusSlot.Type)) return false;
        if (Slot != null && !item.SlotBadges.Any(s => s.Slot?.Id == Slot.Id)) return false;
        if (Badge != null && !item.SlotBadges.Any(s => s.Badge?.Id == Badge.Id)) return false;
        return true;
    }

    // Category はここではクリアしない
    protected void ClearCore()
    {
        Word = string.Empty;
        HasMemo = false;
        Serial = null;
        LimitedSerial = null;
        Tag = null;
        UnlockSlot = null;
        BonusSlot = null;
        Slot = null;
        Badge = null;
    }

    protected virtual void Refresh()
    {
        if (!IsIdle) return;
        ItemsView.Refresh();
    }

}
