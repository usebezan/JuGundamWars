using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal abstract partial class PageControllerViewModelBase2 : ModelBase
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
