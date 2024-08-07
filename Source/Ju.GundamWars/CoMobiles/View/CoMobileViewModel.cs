using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Commons.View;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileViewModel(CoMobileListViewModel listViewModel, CoMobileEntryViewModel entryViewModel)
    : PageControllerViewModelBase<CoMobile, CoMobileListViewModel, CoMobileEntryViewModel>(listViewModel, entryViewModel)
{
}
