using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.Share.Serials.Domain.Service;

public class SerialMapper<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ISerial
    where TDest : ISerial
{
    public TDest Map(TSrc src, TDest dest)
    {
        dest.Id = src.Id;
        dest.Name = src.Name;
        dest.Order = src.Order;
        return dest;
    }
}
