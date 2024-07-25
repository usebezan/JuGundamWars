namespace Ju.GundamWars.Commons.UseCase.OutputPort;

public interface IInsertPresenter<TOut> : IPresenter<TOut>, IDialogicalPresenter, IProgressivePresenter
{
}
