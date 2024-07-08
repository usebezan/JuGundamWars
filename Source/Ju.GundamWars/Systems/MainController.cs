using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Ju.GundamWars.Systems;

public class MainController(ILoadAllUseCase loadAllUseCase, IReloadAllUseCase reloadAllUseCase, IOptions<SystemOption> systemOptions)
{

    private readonly SystemOption systemOption = systemOptions.Value;


    public Task LoadAsync() => loadAllUseCase.HandleAsync();
    public Task ReloadAsync() => reloadAllUseCase.HandleAsync();

    public Task VisitGitHubAsync() =>
        Task.Run(() =>
        {
            using var _ = Process.Start(new ProcessStartInfo() { FileName = systemOption.GitHubUri, UseShellExecute = true, });
        });

}
