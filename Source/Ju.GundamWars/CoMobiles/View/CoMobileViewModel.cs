using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.CoMobiles.View;

internal partial class CoMobileViewModel : ModelBase
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
