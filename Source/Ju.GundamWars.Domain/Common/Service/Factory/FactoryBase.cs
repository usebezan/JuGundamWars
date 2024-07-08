using Ju.GundamWars.Domain.Common.Service.Mapping;

namespace Ju.GundamWars.Domain.Common.Service.Factory;

public abstract class FactoryBase<TSrc, TDest, TApplier>(TApplier applier)
    : IFactory<TSrc, TDest>
    where TSrc : class
    where TDest : class, new()
    where TApplier : IApplier<TSrc, TDest>
{

    public TDest Create(TSrc src) => applier.Apply(src, new());

}
