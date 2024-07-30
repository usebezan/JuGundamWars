using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Systems.Domain;
using Ju.GundamWars.Systems.View;

namespace Ju.GundamWars;

internal partial class MainViewModel(
    ILoadAllClientUseCase loadAllClientUseCase,
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
        ViewState.ShowSnackbar("Loaded.");
    }

    [RelayCommand]
    private void VisitGitHub()
    {

    }

}
