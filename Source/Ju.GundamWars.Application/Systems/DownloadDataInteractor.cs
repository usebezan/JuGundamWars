using Ju.GundamWars.Application.Services;
using Ju.GundamWars.Application.Versionings.Repositories;
using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Options;

namespace Ju.GundamWars.Application.Systems;

public class DownloadDataInteractor(
    HttpService httpService,
    IVersioningRepository versioningRepository,
    IProgressPresenter presenter,
    IOptions<SystemOption> systemOptions,
    WindowStatus windowStatus)
    : IDownloadDataUseCase
{

    private readonly SystemOption systemOption = systemOptions.Value;

    public int ProgressCount => 2;


    private (bool isSuccess1, bool isSame, string version) GetVersion()
    {
        var remoteVersion = httpService.GetString(systemOption.MasterDbVersionUri);
        var localVersion = versioningRepository.SelectById(1)?.Version ?? string.Empty;
        var isSuccess = !string.IsNullOrEmpty(remoteVersion);
        return (isSuccess, remoteVersion == localVersion, isSuccess ? remoteVersion : localVersion);
    }

    public void Handle()
    {
        // 1
        var (isSuccess1, isSame, version) = presenter.Increment("Checking for updated data...", GetVersion);

        windowStatus.Version = version;

        if (!isSuccess1)
        {
            // 2´
            presenter.Increment();
            throw new GwLoadException("Could not check if data are up to date");
        }

        if (isSame)
        {
            presenter.Increment("Data are up to date.");
        }
        else
        {
            // 2
            var isSuccess2 = presenter.Increment(
                "Downloading update data...",
                () => httpService.TryDownloadFile(systemOption.MasterDbFileUri, systemOption.MasterDbFilePath));
            if (!isSuccess2)
            {
                throw new GwLoadException("Could not download update data");
            }
        }
    }

}
