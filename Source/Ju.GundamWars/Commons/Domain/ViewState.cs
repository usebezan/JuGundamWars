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

    [ObservableProperty, NotifyPropertyChangedFor(nameof(VersionText))]
    private string _Version = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasVersionMessage))]
    private string _VersionMessage = string.Empty;
    public string VersionText => string.IsNullOrEmpty(Version) ? string.Empty : $"Ver.{Version}";
    public bool HasVersionMessage => !string.IsNullOrEmpty(VersionMessage);

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SlideIndex))]
    private SlideIndexType _SlideIndexType = SlideIndexType.Main;

    [ObservableProperty, NotifyPropertyChangedFor(nameof(MenuIndexType))]
    private int _MenuIndex = MenuIndexType.Mobile.ToValue();

    public int SlideIndex => SlideIndexType.ToValue();
    public MenuIndexType MenuIndexType => MenuIndex.ToMenuIndexType();


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
