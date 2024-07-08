using Ju.GundamWars.Domain;
using Ju.GundamWars.UseCase;
using System.Threading.Tasks;

namespace Ju.GundamWars;

public abstract class EntryControllerBase<TSubject, TInsertUseCase, TUpdateUseCase, TDeleteUseCase, TCancelUseCase>(
    TInsertUseCase insertUseCase,
    TUpdateUseCase updateUseCase,
    TDeleteUseCase deleteUseCase,
    TCancelUseCase cancelUseCase)
    : IEntryController<TSubject>
    where TSubject : ITaggable
    where TInsertUseCase : IInsertUseCase<TSubject>
    where TUpdateUseCase : IUpdateUseCase<TSubject>
    where TDeleteUseCase : IDeleteUseCase<TSubject>
    where TCancelUseCase : ICancelUseCase<TSubject>
{

    public virtual Task InsertAsync(TSubject entry) => insertUseCase.HandleAsync(entry);
    public virtual Task UpdateAsync(TSubject entry) => updateUseCase.HandleAsync(entry);
    public virtual Task<bool> DeleteAsync(TSubject entry) => deleteUseCase.HandleAsync(entry);
    public virtual Task<bool> CancelAsync(TSubject entry) => cancelUseCase.HandleAsync(entry);

}
