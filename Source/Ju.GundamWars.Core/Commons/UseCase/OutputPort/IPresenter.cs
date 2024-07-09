namespace Ju.GundamWars.Commons.UseCase.OutputPort;

public interface IPresenter
{
    void Complete();
}

public interface IPresenter<TOut>
{
    void Complete(TOut output);
}
