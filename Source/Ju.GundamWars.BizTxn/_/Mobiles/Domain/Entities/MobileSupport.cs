using Ju.GundamWars.BizTxn.Supports.Domain.Dto;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;

public class MobileSupport
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? SupportId { get; set; }

    public Mobile? Mobile { get; set; }
    public SupportDto? Support { get; set; }

}
