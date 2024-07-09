using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.Core.CoMobiles.Domain.Dto;

public class CoMobileTagMap
{

    public int CoMobileId { get; set; }
    public int TagId { get; set; }

    public CoMobile? CoMobile { get; set; }
    public Tag? Tag { get; set; }

}
