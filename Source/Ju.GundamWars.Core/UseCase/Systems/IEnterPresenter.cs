namespace Ju.GundamWars.UseCase.Systems;

public interface IEnterPresenter
{
    Task<bool> AskAsync(string title, string message);
    void Cancel();
    void Abort(string message);
    void Complete(string message);
}
