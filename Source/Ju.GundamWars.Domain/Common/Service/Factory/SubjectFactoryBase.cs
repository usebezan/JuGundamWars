using Ju.GundamWars.Domain.Common.Service.Mapping;

namespace Ju.GundamWars.Domain.Common.Service.Factory;

public abstract class SubjectFactoryBase<TEntity, TSubject, TSubjectMapper>(TSubjectMapper subjectMapper)
    : IFactory<TSubject>, IFactory<TEntity, TSubject>
    where TEntity : class, new()
    where TSubject : class, new()
    where TSubjectMapper : IMapper<TEntity, TSubject>
{

    protected readonly TSubjectMapper SubjectMapper = subjectMapper;


    public TSubject Create() => SubjectMapper.Map(new TEntity(), new());
    public TSubject Create(TEntity src) => SubjectMapper.Map(src, new());

}
