using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.CoMobiles;
using Ju.GundamWars.UseCase.Systems;
using Ju.GundamWars.UseCase.Tags;
using System;
using System.Linq;
using System.Reactive.Linq;
using System.Windows.Data;

namespace Ju.GundamWars.CoMobiles;

public partial class CoMobileListViewModel : CoMobileListViewModelBase
{

    public CoMobileListViewModel(
        CoMobileListController controller,
        ICoMobileInventory CoMobileInventory,
        ICategoryInventory categoryInventory,
        ISerialInventory serialInventory,
        ITagInventory tagInventory)
        : base(CoMobileInventory, serialInventory, tagInventory)
    {
        this.controller = controller;

        Inventory = CoMobileInventory;
        Categories = new(categoryInventory) { Filter = FilterCategory, };

        Inventory.ItemPropertyChanged.Where(n => n == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);

        IsIdle = true;
    }


    private readonly CoMobileListController controller;

    public ICoMobileInventory Inventory { get; }
    public ListCollectionView Categories { get; }

    [ObservableProperty]
    private bool _IsChecked = false;
    [ObservableProperty]
    private bool _IsPinned = false;
    [ObservableProperty]
    private bool _HasMobile = false;

    [ObservableProperty]
    private int _CheckedCount = 0;
    [ObservableProperty]
    private int _FilteredCheckedCount = 0;


    partial void OnIsCheckedChanged(bool value) => Refresh();
    partial void OnIsPinnedChanged(bool value) => Refresh();
    partial void OnHasMobileChanged(bool value) => Refresh();

    private void WhenIsCheckedChanged(string? _) => SetCount();

    private bool FilterCategory(object obj)
    {
        if (obj is not Category item) return false;
        return item.Type.ForCoMobile();
    }

    protected override bool Filter(object obj)
    {
        if (obj is not CoMobileSubject item) return false;
        if (IsChecked && !item.IsChecked) return false;
        if (IsPinned && !item.IsPinned) return false;
        if (HasMobile && item.Mobile == null) return false;
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
        FilteredCheckedCount = ItemsView.OfType<CoMobileSubject>().Where(e => e.IsChecked).Count();
    }

    [RelayCommand]
    private void OpenEntryAsNewForMs() => controller.OpenEntryAsNew();
    [RelayCommand]
    private void OpenEntryAsNewForMa() => controller.OpenEntryAsNewForMa();
    [RelayCommand]
    private void OpenEntryAsEdit(CoMobileSubject CoMobile) => controller.OpenEntryAsEdit(CoMobile);
    [RelayCommand]
    private void OpenEntryAsCopy(CoMobileSubject CoMobile) => controller.OpenEntryAsCopy(CoMobile);

    [RelayCommand]
    private void ChechAll() => ItemsView.ChechAll<CoMobileSubject>(true);
    [RelayCommand]
    private void UnchechAll() => ItemsView.ChechAll<CoMobileSubject>(false);

    [RelayCommand]
    private void Clear()
    {
        IsIdle = false;
        ClearCore();
        Category = null;
        IsChecked = false;
        IsPinned = false;
        HasMobile = false;
        IsIdle = true;
        Refresh();
    }

}
