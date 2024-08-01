using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Commons.View;

internal partial class ProgressViewModel : ModelBase
{

    [ObservableProperty]
    private bool _IsIndeterminate = false;
    [ObservableProperty]
    private string _Message = string.Empty;

}
