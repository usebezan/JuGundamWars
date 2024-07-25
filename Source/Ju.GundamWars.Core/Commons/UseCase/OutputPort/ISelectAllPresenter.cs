namespace Ju.GundamWars.Commons.UseCase.OutputPort;

public interface ISelectAllPresenter<TOut> : IPresenter<List<TOut>>, IProgressivePresenter
{
}
