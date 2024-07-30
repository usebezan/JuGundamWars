using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileEntryViewModel : ModelBase
{

    public CoMobileEntryViewModel(
        CoMobileViewModel coMobileViewModel,
        SerialInventory serials,
        TagInventory tags)
    {
        this.coMobileViewModel = coMobileViewModel;
    }


    private CoMobileViewModel coMobileViewModel;


    [RelayCommand]
    private Task CancelAsync()
    {
        return Task.Run(() =>
        {
            coMobileViewModel.PageIndex = 0;
        });
    }

}
