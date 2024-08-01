using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Cuspas.Domain;

internal partial class CuspaViewState : ModelBase, IPageController
{

    [ObservableProperty]
    private int _PageIndex = 0;

}
