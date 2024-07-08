namespace Ju.GundamWars.UseCase;

public interface IUpdateUseCase<TSubject>
{
    Task HandleAsync(TSubject subject);
}
