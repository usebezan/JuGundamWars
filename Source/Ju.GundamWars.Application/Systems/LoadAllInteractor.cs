using Ju.GundamWars.UseCase.Systems;

namespace Ju.GundamWars.Application.Systems;

public class LoadAllInteractor(
    IDownloadDataUseCase downloadDataUseCase,
    ILoadConstDataUseCase loadConstDataUseCase,
    ILoadUserDataUseCase loadUserDataUseCase,
    IProgressPresenter presenter)
    : LoadAllInteractorBase(presenter), ILoadAllUseCase
{

    protected override List<ISystemUseCase> GetUseCases() => [downloadDataUseCase, loadConstDataUseCase, loadUserDataUseCase,];
    protected override string GetSnackbarMessage() => "Welcome to J.U Gundam Wars!";

}
