namespace Ju.GundamWars.UseCase;

public interface ICancelUseCase<TSubject>
{
    Task<bool> HandleAsync(TSubject subject);
}
