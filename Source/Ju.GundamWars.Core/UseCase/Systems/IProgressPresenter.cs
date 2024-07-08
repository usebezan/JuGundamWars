namespace Ju.GundamWars.UseCase.Systems;

public interface IProgressPresenter
{
    void Initialize(int maximum);
    void ShowMessage(string message);
    void Increment();
    void Increment(Action action);
    T Increment<T>(Func<T> func);
    void Increment(string message);
    void Increment(string message, Action action);
    T Increment<T>(string message, Func<T> func);
    void Complete(string snackbarMessage);
    void CompleteWithWarning(string snackbarMessage, string statusbarMessage);
}
