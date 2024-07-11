using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;

namespace Ju.GundamWars.Application;

public abstract class CancelInteractorBase<TEntity, TSubject, TRepository, TEntityFactory, TSubjectMapper>(
    TRepository repository,
    TEntityFactory entityFactory,
    TSubjectMapper subjectMapper,
    IEnterPresenter presenter,
    ILogger logger)
    : ICancelUseCase<TSubject>
    where TEntity : class
    where TSubject : class, IIdentify
    where TRepository : IRepository<TEntity>
    where TEntityFactory : IFactory<TSubject, TEntity>
    where TSubjectMapper : IMapper<TEntity, TSubject>
{

    private static readonly JsonSerializerOptions options = new()
    {
        Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
        WriteIndented = true,
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    };


    public async Task<bool> HandleAsync(TSubject entry)
    {
        logger.LogDebug("HandleAsync start.");
        var curEntity = repository.SelectById(entry.Id);
        var newEntity = entityFactory.Create(entry);
        var curString = JsonSerializer.Serialize(curEntity, options);
        var newString = JsonSerializer.Serialize(newEntity, options);
#if DEBUG
        File.WriteAllText("curString.txt", curString);
        File.WriteAllText("newString.txt", newString);
#endif
        var isOk = true;
        if (curString != newString)
        {
            isOk = await presenter.AskAsync("CANCEL?", "Are you sure you want to close without registering?");
        }
        if (isOk)
        {
            if (curEntity != null)
            {
                subjectMapper.Apply(curEntity, entry);
            }
            presenter.Cancel();
        }
        logger.LogDebug("HandleAsync end.");
        return isOk;
    }

}
