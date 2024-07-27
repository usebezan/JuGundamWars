using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;
using Ju.GundamWars.Share.Tags.Domain;
using Ju.GundamWars.Share.Units.Domain;

namespace Ju.GundamWars.Share.Pilots.Domain;

public interface IPilot : IIdentifiable
{

    #region Primitives

    string Name { get; set; }
    UnitType ForUnitType { get; set; }
    int SerialId { get; set; }
    GradeType GradeType { get; set; }
    byte Level { get; set; }
    int PilotSkillId { get; set; }
    string? PilotSkillText1 { get; set; }
    string? PilotSkillText2 { get; set; }
    string? Memo { get; set; }
    bool IsPinned { get; set; }

    #endregion

}

public interface IPilot<TStatus> : IPilot
    where TStatus : IPilotStatus
{

    #region Primitive Models

    TStatus BasicStatus { get; }
    TStatus PracticedStatus { get; }

    #endregion

}

public interface IPilot<TStatus, TSlotAbility, TTagLink> : IPilot<TStatus>, ITagMaps<TTagLink>
    where TStatus : IPilotStatus
    where TSlotAbility : IPilotSlotAbility
    where TTagLink : IPilotTagLink
{

    #region Navigations

    List<TSlotAbility> PilotSlotAbilities { get; set; }

    #endregion

}
