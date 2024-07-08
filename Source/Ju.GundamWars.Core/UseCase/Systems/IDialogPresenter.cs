namespace Ju.GundamWars.UseCase.Systems;

public interface IDialogPresenter
{
    Task<bool> AskAsync(string title, string message);
}
