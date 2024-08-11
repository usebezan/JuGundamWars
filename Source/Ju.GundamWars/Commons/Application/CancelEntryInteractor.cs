using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Commons.Domain.Service.Mapping;
using Ju.GundamWars.Commons.UseCase.InputPort;
using Ju.GundamWars.Commons.UseCase.OutputPort;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Ju.GundamWars.Commons.Application;

public class CancelEntryInteractor<T>(
    IMapper<T, T> mapper,
    ICancelEntryPresenter presenter,
    ILogger<CancelEntryInteractor<T>> logger)
    : IGw, ICancelEntryUseCase<T>
{

    private static readonly JsonSerializerOptions options = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    };


    public Task HandleAsync((T @new, T? org) input) =>
        this.Execute(logger, async () =>
        {
            presenter.Initialize();
            var newString = JsonSerializer.Serialize(input.@new, options);
            var orgString = JsonSerializer.Serialize(input.org, options);
            if (newString != orgString)
            {
                var answer = await presenter.ShowMessageAsync(MessageAnswer.OkCancel);
                if (answer != MessageAnswer.Ok)
                {
                    logger.LogInformation("Processing was interrupted by the user.");
                    presenter.Cancel();
                    return;
                }
                if (input.org != null)
                {
                    mapper.Map(input.org, input.@new);
                }
            }
            presenter.Complete();
        });

}
