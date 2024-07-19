using Ju.GundamWars.Share.Grades.Domain;

namespace Ju.GundamWars.Share.MobileSSkills.Domain;

public record MobileSSkillPrimitiveBase : IMobileSSkillPrimitive
{

    #region Primitives

    public int Id { get; set; }
    public int SkillId { get; set; }
    public string NameSuffix { get; set; } = null!;
    public GradeType Grade { get; set; } = GradeType.Grade1;
    public int Order { get; set; }

    #endregion

}
