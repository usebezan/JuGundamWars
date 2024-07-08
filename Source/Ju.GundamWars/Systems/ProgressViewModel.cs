using CommunityToolkit.Mvvm.ComponentModel;

namespace Ju.GundamWars.Systems;

public partial class ProgressViewModel : GwObservableObject
{

    [ObservableProperty]
    private string _Icon = "RobotIndustrial";
    [ObservableProperty]
    private string _Title = "Processing...";
    [ObservableProperty]
    private int _Maximum = 10;
    [ObservableProperty]
    private int _Value = 0;
    [ObservableProperty]
    private string _Message = string.Empty;

}
