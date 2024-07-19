using Ju.GundamWars.Commons.Domain;
using Ju.GundamWars.Share.Grades.Domain;

namespace Ju.GundamWars.Share.MobileSSkills.Domain;

public interface IMobileSSkillPrimitive : IIdentify, IOrderable
{

    #region Primitives

    int SkillId { get; set; }
    string NameSuffix { get; set; }
    GradeType Grade { get; set; }

    #endregion

}
