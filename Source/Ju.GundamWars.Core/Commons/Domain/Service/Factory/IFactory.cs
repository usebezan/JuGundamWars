namespace Ju.GundamWars.Commons.Domain.Service.Factory;

public interface IFactory<T>
{
    T Create();
}

public interface IFactory<TSrc, TDest> : IFactory<TDest>
{
    TDest Create(TSrc src);
}

public interface IFactory<TSrc, TDest, TMapper> : IFactory<TDest>
{
    TMapper Mapper { get; }
    TDest Create(TSrc src);
}
