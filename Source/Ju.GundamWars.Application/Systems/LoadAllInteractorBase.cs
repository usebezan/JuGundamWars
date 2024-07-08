using Ju.GundamWars.UseCase.Systems;

namespace Ju.GundamWars.Application.Systems;

public abstract class LoadAllInteractorBase(IProgressPresenter presenter)
{

    protected abstract List<ISystemUseCase> GetUseCases();
    protected abstract string GetSnackbarMessage();


    public async Task HandleAsync()
    {
        List<ISystemUseCase> useCases = GetUseCases();
        var snackbarMessage = GetSnackbarMessage();
        Action complete = () => presenter.Complete(snackbarMessage);
        presenter.Initialize(useCases.Sum(u => u.ProgressCount));
        await Task.Run(() =>
        {
            foreach (var useCase in useCases)
            {
                try
                {
                    useCase.Handle();
                }
                catch (GwLoadException ex)
                {
                    complete = () => presenter.CompleteWithWarning(snackbarMessage, ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        });
        complete();
    }

}
