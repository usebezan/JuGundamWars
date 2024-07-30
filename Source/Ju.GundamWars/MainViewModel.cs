using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.CoMobiles.View;
using Ju.GundamWars.Systems.Domain;

namespace Ju.GundamWars;

internal partial class MainViewModel(
    ILoadAllClientUseCase loadAllClientUseCase,
    CoMobileListViewModel coMobileListViewModel,
    Menus menus,
    ViewState viewState) : ModelBase
{

    public Menus Menus { get; } = menus;
    public ViewState ViewState { get; } = viewState;


    [RelayCommand]
    private async Task LoadAsync()
    {
        await loadAllClientUseCase.HandleAsync();
        ViewState.ShowSnackbar("Welcome to J.U Gundam Wars.");
    }

    [RelayCommand]
    private async Task ReloadAsync()
    {
        await loadAllClientUseCase.HandleAsync();
        coMobileListViewModel.SetCount();
        ViewState.ShowSnackbar("Loaded.");
    }

    [RelayCommand]
    private void VisitGitHub()
    {

    }

}
