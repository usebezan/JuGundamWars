namespace Ju.GundamWars.Domain.Common.Service.Mapping;

public interface IMapper<TSrc, TDest>
{
    TDest Map(TSrc src, TDest dest);
}
