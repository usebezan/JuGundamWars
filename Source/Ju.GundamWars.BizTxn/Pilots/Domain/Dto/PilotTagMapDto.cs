using Ju.GundamWars.BizTxn.Tags.Domain.Dto;

namespace Ju.GundamWars.BizTxn.Pilots.Domain.Dto;

public class PilotTagMapDto
{

    #region Primitives

    public int PilotId { get; set; }
    public int TagId { get; set; }

    #endregion

    #region Navigations

    public PilotDto? Pilot { get; set; }
    public TagDto? Tag { get; set; }

    #endregion

}
