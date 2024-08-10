namespace Ju.GundamWars.Commons.Domain.Service.Mapping;

public interface IMapper<T>
{
    T Map(T src, T dest);
}

public interface IMapper<TSrc, TDest>
{
    TDest Map(TSrc src, TDest dest);
}
