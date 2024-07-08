namespace Ju.GundamWars.UseCase.Common.InputPort;

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
