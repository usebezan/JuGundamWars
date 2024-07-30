using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using System.ComponentModel;
using System.Reactive.Linq;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileListViewModel : CoMobileListViewModelBase
{

    public CoMobileListViewModel(
        CoMobileViewModel coMobileViewModel,
        CoMobileInventory coMobiles,
        SerialInventory serials,
        TagInventory tags) : base(coMobiles, serials, tags)
    {
        this.coMobileViewModel = coMobileViewModel;

        CoMobiles.ItemPropertyChanged.Where(e => e.PropertyName == "IsChecked").Subscribe(WhenIsCheckedChanged).AddTo(Disposables);
    }


    private readonly CoMobileViewModel coMobileViewModel;

    [ObservableProperty]
    private int _CheckedCount = 0;
    [ObservableProperty]
    private int _FilteredCheckedCount = 0;


    private void WhenIsCheckedChanged(PropertyChangedEventArgs _) => SetCount();

    private void SetCount()
    {
        CheckedCount = CoMobiles.Where(e => e.IsChecked).Count();
        FilteredCheckedCount = ItemsView.OfType<CoMobile>().Where(e => e.IsChecked).Count();
    }

    protected override void Refresh()
    {
        base.Refresh();
        if (!IsIdle) return;
        SetCount();
    }

    [RelayCommand]
    private Task OpenEntryAsNewAsync() =>
        Task.Run(() =>
        {
            coMobileViewModel.PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsEditAsync(CoMobile model) =>
        Task.Run(() =>
        {
            coMobileViewModel.PageIndex = 1;
        });

    [RelayCommand]
    private Task OpenEntryAsCopyAsync(CoMobile model) =>
        Task.Run(() =>
        {
            coMobileViewModel.PageIndex = 1;
        });

    [RelayCommand]
    private void CheckAll() => ItemsView.CheckAll<CoMobile>();
    [RelayCommand]
    private void UncheckAll() => ItemsView.UncheckAll<CoMobile>();

}
