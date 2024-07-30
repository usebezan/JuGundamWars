using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Systems.View;

internal partial class MenuItemViewModel : ModelBase
{

    [ObservableProperty]
    private string _Icon = GwIcon.Unknown;
    [ObservableProperty]
    private string _Text = GwText.Unknown;

}
