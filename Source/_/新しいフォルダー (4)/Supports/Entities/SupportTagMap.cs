using Ju.GundamWars.Domain.Tags.Entities;

namespace Ju.GundamWars.Domain.Supports.Entities;

public class SupportTagMap
{

    public int SupportId { get; set; }
    public int TagId { get; set; }

    public Support? Support { get; set; }
    public Tag? Tag { get; set; }

}
