using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportViewModel(SupportListViewModel listViewModel, SupportEntryViewModel entryViewModel)
    : PageControllerViewModelBase<Support, SupportListViewModel, SupportEntryViewModel>(listViewModel, entryViewModel)
{
    [RelayCommand]
    private Task OpenEntryAsNewForMaAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });
}
