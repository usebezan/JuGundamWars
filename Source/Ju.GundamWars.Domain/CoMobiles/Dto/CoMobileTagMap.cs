using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Domain.CoMobiles.Dto;

public class CoMobileTagMap
{

    public int CoMobileId { get; set; }
    public int TagId { get; set; }

    public CoMobile? CoMobile { get; set; }
    public Tag? Tag { get; set; }

}
