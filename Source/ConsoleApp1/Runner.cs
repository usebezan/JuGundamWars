using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Tags.Infrastructure.WebClient;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Ju.GundamWars.Share.Tags.Domain.Service;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1;

internal class Runner(
    ILoadAllClientUseCase loadAllClientUseCase,
    TagInventory tags,
    IUpdatePresentableUseCase<Tag, TagWebClient, IUpdatePresenter<Tag>, UpdateTagSanitizer<Tag>> updateTagClientUseCase,
    ILogger<Runner> logger)
{
    public async Task RunAsync()
    {
        logger.LogInformation("Load all.");
        await loadAllClientUseCase.HandleAsync();

        logger.LogInformation("Update Tag. Id: 3");
        var tag = tags.FirstOrDefault(m => m.Id == 3);
        if (tag != null)
        {
            tag.Name = "hoge";
            await updateTagClientUseCase.HandleAsync(tag);
        }
    }
}
