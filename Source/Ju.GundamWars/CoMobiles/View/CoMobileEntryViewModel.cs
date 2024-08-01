using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.CoMobiles.Domain;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileEntryViewModel : EntryViewModelBase<CoMobileViewState>
{

    public CoMobileEntryViewModel(
        CoMobileViewState viewState,
        SerialInventory serials,
        TagInventory tags)
        : base(viewState)
    {
    }

}
