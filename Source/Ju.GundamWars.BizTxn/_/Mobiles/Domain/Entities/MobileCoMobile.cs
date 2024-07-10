using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Dto;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;

public class MobileCoMobile
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? CoMobileId { get; set; }

    public Mobile? Mobile { get; set; }
    public CoMobile? CoMobile { get; set; }

}
