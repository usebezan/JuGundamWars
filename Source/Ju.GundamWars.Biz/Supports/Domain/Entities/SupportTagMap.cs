using Ju.GundamWars.Tags.Domain.Dto;

namespace Ju.GundamWars.Supports.Domain.Entities;

public class SupportTagMap
{

    public int SupportId { get; set; }
    public int TagId { get; set; }

    public Support? Support { get; set; }
    public Tag? Tag { get; set; }

}
