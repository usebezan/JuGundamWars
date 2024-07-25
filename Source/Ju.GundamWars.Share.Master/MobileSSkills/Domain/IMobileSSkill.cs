using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;

namespace Ju.GundamWars.Share.MobileSSkills.Domain;

public interface IMobileSSkill : IIdentifiable, IOrderable
{

    #region Primitives

    int SkillId { get; set; }
    string NameSuffix { get; set; }
    GradeType Grade { get; set; }

    #endregion

}
