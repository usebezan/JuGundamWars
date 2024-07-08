using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public partial class WindowStatus : GwObservableObject
{

    [ObservableProperty]
    private string _Version = string.Empty;

    [ObservableProperty]
    private bool _IsBusy = false;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SlideIndex))]
    private SlideIndexType _SlideIndexType = SlideIndexType.Progress;
    public int SlideIndex => SlideIndexType.ToValue();

    [ObservableProperty, NotifyPropertyChangedFor(nameof(TabIndexType))]
    private int _TabIndex = TabIndexType.Mobile.ToValue();
    public TabIndexType TabIndexType => TabIndex.ToTabIndexType();

    [ObservableProperty]
    private string _StatusbarIcon = GwIcon.Information;
    [ObservableProperty]
    private string _StatusbarMessage = string.Empty;

}
