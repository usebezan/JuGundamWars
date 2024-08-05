using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Pilots.Domain;

internal partial class PilotViewState : ModelBase, IPageController
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
