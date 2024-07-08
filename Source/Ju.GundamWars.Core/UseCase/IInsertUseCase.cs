namespace Ju.GundamWars.UseCase;

public interface IInsertUseCase<TSubject>
{
    Task HandleAsync(TSubject subject);
}
