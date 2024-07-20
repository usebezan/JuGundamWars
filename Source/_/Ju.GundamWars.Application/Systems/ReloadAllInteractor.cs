namespace Ju.GundamWars.Application.Systems;

public class ReloadAllInteractor(
    IDownloadDataUseCase downloadDataUseCase,
    ILoadUserDataUseCase loadUserDataUseCase,
    IProgressPresenter presenter)
    : LoadAllInteractorBase(presenter), IReloadAllUseCase
{

    protected override List<ISystemUseCase> GetUseCases() => [downloadDataUseCase, loadUserDataUseCase,];
    protected override string GetSnackbarMessage() => "Reload completed.";

}
