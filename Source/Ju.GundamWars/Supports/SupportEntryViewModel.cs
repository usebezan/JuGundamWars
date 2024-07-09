using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.SupportSlotBadges;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.Domain.Tags;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Entities;
using Ju.GundamWars.Supports.Domain.Factories;
using Ju.GundamWars.UseCase.Supports;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Supports;

public partial class SupportEntryViewModel : EntryViewModelBase<SupportSubject, SupportEntryController, SupportSubjectFactory>
{

    public SupportEntryViewModel(
        SupportEntryController controller,
        SupportSubjectFactory factory,
        ISerialInventory serialInventory,
        IGradeInventory gradeInventory,
        ITagInventory tagInventory,
        ISupportSlotInventory supportSlotInventory,
        ISupportBadgeInventory supportBadgeInventory)
        : base(controller, factory, tagInventory)
    {
        Icon = GwIcon.Support;
        Text = GwText.Support;

        this.supportSlotInventory = supportSlotInventory;

        Serials = new(serialInventory);
        Grades = new(gradeInventory) { Filter = FilterGrade, };
        Tags = new(tagInventory) { Filter = FilterTag, };
        Slots = new(supportSlotInventory);
        UnlockSlots = new(supportSlotInventory) { Filter = FilterUnlockSlot, };
        BonusSlots = new(supportSlotInventory) { Filter = FilterBonusSlot, };
        Badges = new(supportBadgeInventory);

        Slots.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
        UnlockSlots.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
        BonusSlots.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
        Badges.GroupDescriptions.Add(new PropertyGroupDescription("BoostText"));
    }


    private readonly ISupportSlotInventory supportSlotInventory;

    public override int TabIndex => Mode == EntryMode.New ? 0 : 1;

    public ListCollectionView Serials { get; }
    public ListCollectionView Grades { get; }
    public ListCollectionView Tags { get; }
    public ListCollectionView Slots { get; }
    public ListCollectionView UnlockSlots { get; }
    public ListCollectionView BonusSlots { get; }
    public ListCollectionView Badges { get; }

    [ObservableProperty]
    private Serial? _Serial;
    [ObservableProperty]
    private SupportSlot? _UnlockSlot;
    [ObservableProperty]
    private SupportSlot? _BonusSlot;


    private bool FilterGrade(object obj)
    {
        if (obj is not Grade item) return false;
        return item.Type.ForSupport();
    }

    private bool FilterTag(object obj)
    {
        if (obj is not TagSubject item) return false;
        return item.KindType.ForSupport();
    }

    private bool FilterUnlockSlot(object obj)
    {
        if (obj is not SupportSlot item) return false;
        return item.Boost.ForMobile();
    }

    private bool FilterBonusSlot(object obj)
    {
        if (obj is not SupportSlot item) return false;
        return item.Boost.ForBadge();
    }

    private void AddSlotBadge(SupportSlot? slot)
    {
        if (slot != null)
        {
            Entry.SlotBadges.Add(new() { Support = Entry, Slot = slot, });
        }
    }

    [RelayCommand]
    private void AddLimitedSerial()
    {
        if (Serial != null && !Entry.LimitedSerials.Any(i => i.Id == Serial.Id))
        {
            Entry.LimitedSerials.Add(Serial);
        }
    }

    [RelayCommand]
    private void RemoveLimitedSerial(Serial? serial)
    {
        if (serial != null)
        {
            Entry.LimitedSerials.Remove(serial);
        }
    }

    [RelayCommand]
    private void AddUnlockSlotBadge() => AddSlotBadge(UnlockSlot);

    [RelayCommand]
    private void AddBonusSlotBadge() => AddSlotBadge(BonusSlot);

    [RelayCommand]
    private void AddNormalSlotBadge() => AddSlotBadge(supportSlotInventory.FirstOrDefault(i => i.Id == 1));

    [RelayCommand]
    private void RemoveSlotBadge(SupportSlotBadgeSubject? slotBadge)
    {
        if (slotBadge != null)
        {
            Entry.SlotBadges.Remove(slotBadge);
        }
    }

    [RelayCommand]
    private void RemoveAllSlotBadges()
    {
        Entry.SlotBadges.Clear();
    }

    [RelayCommand]
    private void DetachAllBadges() => Entry.DetachAllBadges();

}
