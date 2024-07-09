namespace Ju.GundamWars.Commons.Domain.Service.Mapping;

public interface IMapper<TSrc, TDest>
{
    TDest Map(TSrc src, TDest dest);
}
