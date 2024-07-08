namespace Ju.GundamWars.UseCase.Systems;

public interface ISystemUseCase
{
    int ProgressCount { get; }
    void Handle();
}
