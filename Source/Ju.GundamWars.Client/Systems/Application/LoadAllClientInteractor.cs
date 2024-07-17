using Ju.GundamWars.BizMaster.Commons.Domain;
using Ju.GundamWars.Client.Systems.Infrastructure.WebClient;
using Ju.GundamWars.Client.Systems.UseCase.InputPort;
using Ju.GundamWars.Client.Systems.UseCase.OutputPort;
using Microsoft.Extensions.Logging;

namespace Ju.GundamWars.Client.Systems.Application;

internal class LoadAllClientInteractor(
    SystemWebClient gateway,
    ILoadAllClientPresenter presenter,
    ILogger<LoadAllClientInteractor> logger)
    : ILoadAllClientUseCase, IGw
{
    public Task<DataModels> HandleAsync() =>
        this.Execute(logger, async () =>
        {
            presenter.ShowProgress();
            try
            {
                var models = await gateway.LoadAllAsync();
                presenter.Complete(models);
                return models;
            }
            finally
            {
                presenter.CloseProgress();
            }
        });
}
