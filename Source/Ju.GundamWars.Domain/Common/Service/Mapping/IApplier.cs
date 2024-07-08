namespace Ju.GundamWars.Domain.Common.Service.Mapping;

public interface IApplier<TSrc, TDest>
{
    TDest Apply(TSrc src, TDest dest);
}
