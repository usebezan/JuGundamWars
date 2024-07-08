namespace Ju.GundamWars.Domain;

public interface IFactory<T>
{
    T Create();
}

public interface IFactory<TSrc, TDest>
{
    TDest Create(TSrc src);
}
