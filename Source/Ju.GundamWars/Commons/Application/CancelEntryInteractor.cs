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
    ILogger<CancelEntryInteractor<T>> logger) : IGw, ICancelEntryUseCase<T>
{

    private static readonly JsonSerializerOptions options = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    };


    public Task HandleAsync((EntryMode, T, T?) input) =>
        this.Execute(logger, async () =>
        {
            presenter.Initialize();
            var curString = JsonSerializer.Serialize(input.Item2, options);
            var newString = JsonSerializer.Serialize(input.Item3, options);
            if (curString != newString)
            {
                var answer = await presenter.ShowMessageAsync(MessageAnswer.OkCancel);
                if (answer != MessageAnswer.Ok)
                {
                    logger.LogInformation("Processing was interrupted by the user.");
                    presenter.Cancel();
                    return;
                }
                if (input.Item1 == EntryMode.Edit)
                {
                    mapper.Map(input.Item3!, input.Item2);
                }
            }
            presenter.Complete();
        });

}
