using Ju.GundamWars.Domain;

namespace Ju.GundamWars.UseCase.Common.OutputPort;

public interface IDialogicalPresenter : IPresenter
{
    void Initialize();

    Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices);

    void ShowProgress();
    void CloseProgress();

    void ValidationError(string message);
    void Abort(string message);
    void Cancel();
}

public interface IDialogicalPresenter<TOut> : IPresenter<TOut>
{
    void Initialize();

    Task<MessageAnswer> ShowMessageAsync(MessageAnswer choices);

    void ShowProgress();
    void CloseProgress();

    void ValidationError(string message);
    void Abort(string message);
    void Cancel();
}
