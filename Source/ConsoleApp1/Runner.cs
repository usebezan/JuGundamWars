using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1;

internal class Runner(ILoadAllClientUseCase useCase, ILogger<Runner> logger)
{
    public async Task RunAsync()
    {
        logger.LogInformation("Hello.");
        await useCase.HandleAsync();
    }
}
