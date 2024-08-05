using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Pilots.Domain;

namespace Ju.GundamWars.Pilots.View;

internal partial class PilotEntryViewModel : EntryViewModelBase<PilotViewState>
{

    public PilotEntryViewModel(
        PilotViewState viewState,
        SerialInventory serials,
        TagInventory tags)
        : base(viewState)
    {
    }

}
