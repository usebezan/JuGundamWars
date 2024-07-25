namespace Ju.GundamWars.Commons.UseCase.OutputPort;

public interface IPresenter
{
    void Initialize();
    void ValidationError(string message);
    //void Abort(string message);
    void Cancel();
    void Complete();
}

public interface IPresenter<TOut>
{
    void Initialize();
    void ValidationError(string message);
    //void Abort(string message);
    void Cancel();
    void Complete(TOut output);
}
