namespace Ju.GundamWars.Domain;

public interface IApplier<TSrc, TDest>
{
    TDest Apply(TSrc src, TDest dest);
}
