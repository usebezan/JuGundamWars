using Ju.GundamWars.Client.CoMobiles.Domain;
using Ju.GundamWars.Client.CoMobiles.Infrastructure.WebClient;
using Ju.GundamWars.Client.Roles.Domain;
using Ju.GundamWars.Client.Serials.Domain;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Tags.Domain;
using Ju.GundamWars.Client.Tags.Infrastructure.WebClient;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1;

internal class Runner(
    ILoadAllClientUseCase loadAllClientUseCase,
    RoleInventory roles,
    SerialInventory serials,

    TagInventory tags,
    IUpdatePresentableUseCase<Tag, TagWebClient, IUpdatePresenter<Tag>> updateTagClientUseCase,

    CoMobileInventory coMobiles,
    IInsertPresentableUseCase<CoMobile, CoMobileWebClient, IInsertPresenter<CoMobile>> insertCoMobileClientUseCase,
    IUpdatePresentableUseCase<CoMobile, CoMobileWebClient, IUpdatePresenter<CoMobile>> updateCoMobileClientUseCase,
    IDeletePresentableUseCase<CoMobile, CoMobile, CoMobileWebClient, IDeletePresenter<CoMobile>> deleteCoMobileClientUseCase,

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

        logger.LogInformation("Insert CoMobile.");
        var coMobile1 = new CoMobile()
        {
            Name = "test CoMobile",
            Serial = serials.FirstOrDefault(),
            Role = roles.FirstOrDefault(),
        };
        await insertCoMobileClientUseCase.HandleAsync(coMobile1);

        logger.LogInformation("Update CoMobile. Id: 1");
        var coMobile2 = coMobiles.FirstOrDefault(m => m.Id == 1);
        if (coMobile2 != null)
        {
            coMobile2.Name = "update CoMobile";
            await updateCoMobileClientUseCase.HandleAsync(coMobile2);
        }


    }
}
