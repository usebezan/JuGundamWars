using CommunityToolkit.Mvvm.ComponentModel;

namespace Ju.GundamWars.Systems;

public abstract partial class DialogViewModelBase : GwObservableObject
{

    [ObservableProperty]
    private string _Title = string.Empty;
    [ObservableProperty]
    private string _Message = string.Empty;

}
