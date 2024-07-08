using Ju.GundamWars.Const;
using Ju.GundamWars.Domain;

namespace Ju.GundamWars;

public abstract class ListControllerBase<TEntity, TSubject, TEntryViewModel, TEntityFactory, TSubjectFactory>(
    TEntryViewModel viewModel,
    TEntityFactory entityFactory,
    TSubjectFactory subjectFactory)
    where TEntity : class
    where TSubject : class, IIdentify
    where TEntryViewModel : IEntryViewModel<TSubject>
    where TEntityFactory : IFactory<TSubject, TEntity>
    where TSubjectFactory : IFactory<TSubject>, IFactory<TEntity, TSubject>
{

    protected readonly TEntityFactory EntityFactory = entityFactory;
    protected readonly TSubjectFactory SubjectFactory = subjectFactory;


    protected abstract void MoveToEntry();

    protected void OpenEntry(EntryMode mode, TSubject entry)
    {
        viewModel.SetEntry(mode, entry);
        MoveToEntry();
    }

    public virtual void OpenEntryAsNew() => OpenEntry(EntryMode.New, SubjectFactory.Create());

    public virtual void OpenEntryAsEdit(TSubject subject) => OpenEntry(EntryMode.Edit, subject);

    public virtual void OpenEntryAsCopy(TSubject subject)
    {
        var newSubject = SubjectFactory.Create(EntityFactory.Create(subject));
        // exclude members
        newSubject.Id = 0;
        OpenEntry(EntryMode.Copy, newSubject);
    }

}
