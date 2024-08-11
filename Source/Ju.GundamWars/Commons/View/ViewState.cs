using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using MaterialDesignThemes.Wpf;

namespace Ju.GundamWars.Commons.View;

internal partial class ViewState : ModelBase
{

    public ViewState()
    {
        SnackbarMessageQueue = new SnackbarMessageQueue().AddTo(Disposables);
    }


    public SnackbarMessageQueue SnackbarMessageQueue { get; }


    [ObservableProperty, NotifyPropertyChangedFor(nameof(VersionText))]
    private string _Version = string.Empty;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasVersionMessage))]
    private string _VersionMessage = string.Empty;
    public string VersionText => string.IsNullOrEmpty(Version) ? string.Empty : $"Ver.{Version}";
    public bool HasVersionMessage => !string.IsNullOrEmpty(VersionMessage);

    [ObservableProperty, NotifyPropertyChangedFor(nameof(MenuIndexType))]
    private int _MenuIndex = MenuIndexType.Mobile.ToValue();
    public MenuIndexType MenuIndexType => MenuIndex.ToMenuIndexType();


    partial void OnIsDialogOpenChanged(bool value)
    {
        if (!value)
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

    #region Dialog

    [ObservableProperty]
    private bool _IsDialogOpen;
    [ObservableProperty]
    private object? _DialogContent;

    public void OpenDialog(object content)
    {
        DialogContent = content;
        IsDialogOpen = true;
    }

    public void CloseDialog()
    {
        IsDialogOpen = false;
        DialogContent = null;
    }

    #endregion

    #region Entry

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CoMobilePageIndex))]
    private PageIndexType _CoMobilePageIndexType = PageIndexType.List;

    [ObservableProperty]
    private IDisposable? _CoMobileEntryContent;

    public int CoMobilePageIndex => CoMobilePageIndexType.ToValue();


    [ObservableProperty, NotifyPropertyChangedFor(nameof(CuspaPageIndex))]
    private PageIndexType _CuspaPageIndexType = PageIndexType.List;

    [ObservableProperty]
    private IDisposable? _CuspaEntryContent;

    public int CuspaPageIndex => CuspaPageIndexType.ToValue();


    public void OpenEntry(IDisposable content)
    {
        switch (MenuIndexType)
        {
            case MenuIndexType.Mobile:
                break;
            case MenuIndexType.Pilot:
                break;
            case MenuIndexType.Support:
                break;
            case MenuIndexType.CoMobile:
                CoMobileEntryContent = content;
                CoMobilePageIndexType = PageIndexType.Entry;
                break;
            case MenuIndexType.Cuspa:
                CuspaEntryContent = content;
                CuspaPageIndexType = PageIndexType.Entry;
                break;
            case MenuIndexType.Tag:
                break;
        }
    }

    public void CloseEntry()
    {
        switch (MenuIndexType)
        {
            case MenuIndexType.Mobile:
                break;
            case MenuIndexType.Pilot:
                break;
            case MenuIndexType.Support:
                break;
            case MenuIndexType.CoMobile:
                CoMobilePageIndexType = PageIndexType.List;
                CoMobileEntryContent?.Dispose();
                CoMobileEntryContent = null;
                break;
            case MenuIndexType.Cuspa:
                CuspaPageIndexType = PageIndexType.List;
                CuspaEntryContent?.Dispose();
                CuspaEntryContent = null;
                break;
            case MenuIndexType.Tag:
                break;
        }
    }

    #endregion

}
