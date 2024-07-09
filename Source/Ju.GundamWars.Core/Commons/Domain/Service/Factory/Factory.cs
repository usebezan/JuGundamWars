using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Commons.Domain.Service.Factory;

public class Factory<TSrc, TDest, TMapper>(TMapper mapper) : IFactory<TSrc, TDest, TMapper>
    where TSrc : class, new()
    where TDest : class, new()
    where TMapper : IMapper<TSrc, TDest>
{
    public TMapper Mapper { get; } = mapper;
    public TDest Create() =>
        Mapper.Map(new(), new());
    public TDest Create(TSrc src) =>
        Mapper.Map(src, new());
}
