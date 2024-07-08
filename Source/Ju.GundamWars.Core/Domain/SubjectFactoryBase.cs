namespace Ju.GundamWars.Domain;

public abstract class SubjectFactoryBase<TEntity, TSubject, TSubjectApplier>(TSubjectApplier subjectApplier)
    : IFactory<TSubject>, IFactory<TEntity, TSubject>
    where TEntity : class, new()
    where TSubject : class, new()
    where TSubjectApplier : IApplier<TEntity, TSubject>
{

    protected readonly TSubjectApplier SubjectApplier = subjectApplier;


    public TSubject Create() => SubjectApplier.Apply(new TEntity(), new());
    public TSubject Create(TEntity src) => SubjectApplier.Apply(src, new());

}
