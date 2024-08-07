using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.CoMobiles.View;
using Ju.GundamWars.Systems.Domain;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Ju.GundamWars;

internal partial class MainViewModel(
    ILoadAllClientUseCase loadAllClientUseCase,
    CoMobileListViewModel coMobileListViewModel,
    Menus menus,
    ViewState viewState,
    IOptions<SystemOption> systemOptions) : ModelBase
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
        // TODO: 強引がすぎる
        coMobileListViewModel.SetCount();
        ViewState.ShowSnackbar("Loaded.");
    }

    [RelayCommand]
    private Task VisitGitHubAsync() =>
        Task.Run(() =>
        {
            using var _ = Process.Start(new ProcessStartInfo() { FileName = systemOptions.Value.GitHubUri, UseShellExecute = true, });
        });

}
