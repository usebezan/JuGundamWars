using Ju.GundamWars.Commons.Domain.Service.Mapping;

namespace Ju.GundamWars.BizTxn.Cuspas.Domain.Service.Mapping;

public abstract class CuspaMapperBase<TSrc, TDest> : IMapper<TSrc, TDest>
    where TSrc : ICuspa
    where TDest : ICuspa
{
    public abstract TDest Map(TSrc src, TDest dest);
    protected TDest Map(TSrc src, TDest dest, Action mapper)
    {
        dest.Id = src.Id;
        dest.ForUnit = src.ForUnit;
        dest.Level = src.Level;
        dest.BasicValue = src.BasicValue;
        dest.Memo = src.Memo;
        mapper?.Invoke();
        return dest;
    }
}
