using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.Domain.Pilots;
using Ju.GundamWars.Domain.Supports;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Mobiles;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.Mobiles;

public partial class MobileListViewModel : MobileListViewModelBase
{

    public MobileListViewModel(
        MobileListController controller,
        IMobileInventory mobileInventory,
        ICategoryInventory categoryInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory)
        : base(mobileInventory, serialInventory, tagInventory)
    {
        this.controller = controller;

        Inventory = mobileInventory;
        Categories = new(categoryInventory) { Filter = FilterCategory, };

        Inventory.ItemPropertyChanged.Where(n => n == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly MobileListController controller;

    public IMobileInventory Inventory { get; }
    public ListCollectionView Categories { get; }

    [ObservableProperty]
    private bool _IsChecked = false;
    [ObservableProperty]
    private bool _IsPinned = false;

    [ObservableProperty]
    private int _CheckedCount = 0;
    [ObservableProperty]
    private int _FilteredCheckedCount = 0;


    partial void OnIsCheckedChanged(bool value) => Refresh();
    partial void OnIsPinnedChanged(bool value) => Refresh();

    private void WhenIsCheckedChanged(string? _) => SetCount();

    private bool FilterCategory(object obj)
    {
        if (obj is not Category item) return false;
        return item.Type.ForMobile();
    }

    protected override bool Filter(object obj)
    {
        if (obj is not MobileSubject item) return false;
        if (IsChecked && !item.IsChecked) return false;
        if (IsPinned && !item.IsPinned) return false;
        if (!FilterCore(item)) return false;
        return true;
    }

    protected override void Refresh()
    {
        base.Refresh();
        if (!IsIdle) return;
        SetCount();
    }

    private void SetCount()
    {
        CheckedCount = Inventory.Where(e => e.IsChecked).Count();
        FilteredCheckedCount = ItemsView.OfType<MobileSubject>().Where(e => e.IsChecked).Count();
    }

    [RelayCommand]
    private void OpenEntryAsNewForMs() => controller.OpenEntryAsNew();
    [RelayCommand]
    private void OpenEntryAsNewForMa() => controller.OpenEntryAsNewForMa();
    [RelayCommand]
    private void OpenEntryAsEdit(MobileSubject mobile) => controller.OpenEntryAsEdit(mobile);
    [RelayCommand]
    private void OpenEntryAsCopy(MobileSubject mobile) => controller.OpenEntryAsCopy(mobile);

    [RelayCommand]
    private void OpenPilotAsEdit(PilotSubject pilot) => controller.OpenPilotAsEdit(pilot);
    [RelayCommand]
    private void OpenSupportAsEdit(SupportSubject support) => controller.OpenSupportAsEdit(support);
    [RelayCommand]
    private void OpenCoMobileAsEdit(CoMobileSubject coMobile) => controller.OpenCoMobileAsEdit(coMobile);

    [RelayCommand]
    private void ChechAll() => ItemsView.ChechAll<MobileSubject>(true);
    [RelayCommand]
    private void UnchechAll() => ItemsView.ChechAll<MobileSubject>(false);

    [RelayCommand]
    private void Clear()
    {
        IsIdle = false;
        ClearCore();
        Category = null;
        IsChecked = false;
        IsPinned = false;
        IsIdle = true;
        Refresh();
    }

}
