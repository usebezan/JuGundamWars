using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Cuspas.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Cuspas.View;

internal partial class CuspaViewModel(CuspaListViewModel listViewModel, CuspaEntryViewModel entryViewModel)
    : PageControllerViewModelBase<Cuspa, CuspaListViewModel, CuspaEntryViewModel>(listViewModel, entryViewModel)
{
    [RelayCommand]
    private Task OpenEntryAsNewForBsAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });
}
