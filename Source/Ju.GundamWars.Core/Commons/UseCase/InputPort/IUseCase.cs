namespace Ju.GundamWars.Commons.UseCase.InputPort;

public interface IUseCase
{
    Task HandleAsync();
}

public interface IUseCase<TOut>
{
    Task<TOut> HandleAsync();
}

public interface IUseCase<TIn, TOut>
{
    Task<TOut> HandleAsync(TIn input);
}
