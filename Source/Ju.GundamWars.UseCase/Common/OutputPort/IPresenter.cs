namespace Ju.GundamWars.UseCase.Common.OutputPort;

public interface IPresenter
{
    void Complete();
}

public interface IPresenter<TOut>
{
    void Complete(TOut output);
}
