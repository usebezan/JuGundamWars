using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.CoMobiles.Domain;

internal partial class CoMobileViewState : ModelBase, IPageController
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
