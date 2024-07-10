using Ju.GundamWars.Biz._.CoMobiles.Domain.Dto;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Entities;

public class MobileCoMobile
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? CoMobileId { get; set; }

    public Mobile? Mobile { get; set; }
    public CoMobile? CoMobile { get; set; }

}
