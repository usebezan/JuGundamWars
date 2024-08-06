using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.View;
using Ju.GundamWars.Supports.Domain;

namespace Ju.GundamWars.Supports.View;

internal partial class SupportEntryViewModel : EntryViewModelBase<SupportViewState>
{

    public SupportEntryViewModel(
        SupportViewState viewState,
        SerialInventory serials,
        TagInventory tags)
        : base(viewState)
    {
    }

}
