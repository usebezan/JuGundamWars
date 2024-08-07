using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Pilots.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.Pilots.View;

internal partial class PilotViewModel(PilotListViewModel listViewModel, PilotEntryViewModel entryViewModel)
    : PageControllerViewModelBase<Pilot, PilotListViewModel, PilotEntryViewModel>(listViewModel, entryViewModel)
{
    [RelayCommand]
    private Task OpenEntryAsNewForMaAsync() =>
        Task.Run(() =>
        {
            PageIndex = 1;
        });
}
