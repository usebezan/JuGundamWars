using Ju.GundamWars.Biz.Supports.Domain.Dto;

namespace Ju.GundamWars.Mobiles.Domain.Entities;

public class MobileSupport
{

    public int MobileId { get; set; }
    public byte Seq { get; set; }
    public int? SupportId { get; set; }

    public Mobile? Mobile { get; set; }
    public SupportDto? Support { get; set; }

}
