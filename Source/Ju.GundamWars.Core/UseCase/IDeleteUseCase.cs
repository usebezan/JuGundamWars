namespace Ju.GundamWars.UseCase;

public interface IDeleteUseCase<TSubject>
{
    Task<bool> HandleAsync(TSubject subject);
}
