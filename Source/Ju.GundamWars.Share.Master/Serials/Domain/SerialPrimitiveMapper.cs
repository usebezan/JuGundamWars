using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Serials.Domain;

public class SerialPrimitiveMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISerialPrimitive
    where TDest : ISerialPrimitive
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.Order = src.Order;
        return dest;
    }
}
