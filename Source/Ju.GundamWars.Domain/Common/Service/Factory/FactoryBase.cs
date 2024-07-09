using Ju.GundamWars.Domain.Common.Service.Mapping;

namespace Ju.GundamWars.Domain.Common.Service.Factory;

public abstract class FactoryBase<TSrc, TDest, TMapper>(TMapper Mapper) : IFactory<TSrc, TDest>
    where TSrc : class
    where TDest : class, new()
    where TMapper : IMapper<TSrc, TDest>
{
    public TDest Create(TSrc src) => Mapper.Map(src, new());
}
