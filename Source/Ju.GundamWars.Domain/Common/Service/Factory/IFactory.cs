namespace Ju.GundamWars.Domain.Common.Service.Factory;

public interface IFactory<T>
{
    T Create();
}

public interface IFactory<TSrc, TDest>
{
    TDest Create(TSrc src);
}
