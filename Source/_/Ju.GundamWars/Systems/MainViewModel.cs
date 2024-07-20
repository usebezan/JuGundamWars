using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.CoMobiles;
using Ju.GundamWars.Const;
using Ju.GundamWars.Core;
using Ju.GundamWars.Cuspas;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.Mobiles;
using Ju.GundamWars.Pilots;
using Ju.GundamWars.Supports;
using Ju.GundamWars.UseCase.Systems;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Ju.GundamWars.Systems;

public partial class MainViewModel : GwObservableObject
{

    public MainViewModel(
        MainController controller,
        CoMobileListViewModel CoMobileListViewModel,
        CuspaListViewModel cuspaListViewModel,
        MobileListViewModel mobileListViewModel,
        PilotListViewModel pilotListViewModel,
        SupportListViewModel supportListViewModel,
        WindowStatus windowStatus,
        ISnackbarPresenter snackbar)
    {
        this.controller = controller;
        this.CoMobileListViewModel = CoMobileListViewModel;
        this.cuspaListViewModel = cuspaListViewModel;
        this.mobileListViewModel = mobileListViewModel;
        this.pilotListViewModel = pilotListViewModel;
        this.supportListViewModel = supportListViewModel;
        WindowStatus = windowStatus;
        Snackbar = snackbar;
        ActiveList = mobileListViewModel;

        windowStatus.PropertyChanged.Where(n => n == "TabIndex").Subscribe(WhenTabIndexChanged).AddTo(Disposables);
    }


    private readonly MainController controller;
    private readonly CoMobileListViewModel CoMobileListViewModel;
    private readonly CuspaListViewModel cuspaListViewModel;
    private readonly MobileListViewModel mobileListViewModel;
    private readonly PilotListViewModel pilotListViewModel;
    private readonly SupportListViewModel supportListViewModel;

    public WindowStatus WindowStatus { get; }
    public ISnackbarPresenter Snackbar { get; }

    [ObservableProperty]
    private object? _ActiveList = null;


    private void WhenTabIndexChanged(string? _)
    {
        switch (WindowStatus.TabIndexType)
        {
            case TabIndexType.CoMobile:
                ActiveList = CoMobileListViewModel;
                break;
            case TabIndexType.Cuspa:
                //ActiveList = cuspaListViewModel;
                ActiveList = null;
                break;
            case TabIndexType.Mobile:
                ActiveList = mobileListViewModel;
                break;
            case TabIndexType.Pilot:
                ActiveList = pilotListViewModel;
                break;
            case TabIndexType.Support:
                ActiveList = supportListViewModel;
                break;
            default:
                ActiveList = null;
                break;
        }
    }


    [RelayCommand]
    private Task LoadAsync() => controller.LoadAsync();

    [RelayCommand]
    private Task ReloadAsync() => controller.ReloadAsync();

    [RelayCommand]
    private Task VisitGitHubAsync() => controller.VisitGitHubAsync();

}
