using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Systems.View;

internal partial class LoadAllProgressViewModel : ModelBase
{

    [ObservableProperty]
    private bool _IsIndeterminate = false;

}
