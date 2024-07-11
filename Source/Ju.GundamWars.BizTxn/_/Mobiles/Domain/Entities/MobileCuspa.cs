using Ju.GundamWars.BizTxn.Cuspas.Domain.Dto;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;

public class MobileCuspa
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int CuspaId { get; set; }

    public Mobile? Mobile { get; set; }
    public CuspaDto? Cuspa { get; set; }

}
