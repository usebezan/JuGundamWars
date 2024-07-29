using CommunityToolkit.Mvvm.Input;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars;

internal partial class MainViewModel(
    ILoadAllClientUseCase loadAllClientUseCase,
    ViewState viewState) : ModelBase
{

    public ViewState ViewState { get; } = viewState;


    [RelayCommand]
    private async Task LoadAsync()
    {
        await loadAllClientUseCase.HandleAsync();
        ViewState.ShowSnackbar("Loaded.");
    }

    [RelayCommand]
    private void VisitGitHub()
    {

    }

}
