using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain.Model;
using MaterialDesignThemes.Wpf;

namespace Ju.GundamWars.Commons.Domain;

internal partial class ViewState : ModelBase
{

    public ViewState()
    {
        SnackbarMessageQueue = new SnackbarMessageQueue().AddTo(Disposables);
    }


    public SnackbarMessageQueue SnackbarMessageQueue { get; }

    [ObservableProperty]
    private bool _IsDialogOpen;
    [ObservableProperty]
    private object? _DialogContent;

    [ObservableProperty]
    private string _Version = string.Empty;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SlideIndex))]
    private SlideIndexType _SlideIndexType = SlideIndexType.Main;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(TabIndexType))]
    private int _TabIndex = TabIndexType.Mobile.ToValue();

    public int SlideIndex => SlideIndexType.ToValue();
    public TabIndexType TabIndexType => TabIndex.ToTabIndexType();


    partial void OnIsDialogOpenChanged(bool value)
    {
        if (!IsDialogOpen)
        {
            DialogContent = null;
        }
    }


    public void ShowSnackbar(string message) =>
        SnackbarMessageQueue.Enqueue(message, "Close", SnackbarMessageQueue.Clear);


    //[ObservableProperty]
    //private int _SlideIndex = 0;

    //[ObservableProperty]
    //private bool _IsBusy = false;


    //[ObservableProperty]
    //private string _StatusbarIcon = GwIcon.Information;
    //[ObservableProperty]
    //private string _StatusbarMessage = string.Empty;

}
