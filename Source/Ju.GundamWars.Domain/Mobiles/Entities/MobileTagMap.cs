using Ju.GundamWars.Domain.Tags.Dto;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileTagMap
{

    public int MobileId { get; set; }
    public int TagId { get; set; }

    public Mobile? Mobile { get; set; }
    public Tag? Tag { get; set; }

}
