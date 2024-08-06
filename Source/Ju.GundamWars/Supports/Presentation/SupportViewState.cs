using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Supports.Domain;

internal partial class SupportViewState : ModelBase, IPageController
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
