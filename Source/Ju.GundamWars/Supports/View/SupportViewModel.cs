using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Supports.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportViewModel(SupportListViewModel listViewModel)
    : PageControllerViewModelBase<Support, SupportListViewModel>(listViewModel)
{
    [RelayCommand]
    private Task OpenEntryAsNewForMaAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });
}
