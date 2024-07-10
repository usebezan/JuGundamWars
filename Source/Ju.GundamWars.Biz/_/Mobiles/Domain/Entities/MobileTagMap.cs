using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.Biz._.Mobiles.Domain.Entities;

public class MobileTagMap
{

    public int MobileId { get; set; }
    public int TagId { get; set; }

    public Mobile? Mobile { get; set; }
    public Tag? Tag { get; set; }

}
