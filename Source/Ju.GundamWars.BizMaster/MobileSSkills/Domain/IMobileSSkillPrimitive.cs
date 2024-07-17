using Ju.GundamWars.BizConst.Grades.Domain;
using Ju.GundamWars.Commons.Domain;

namespace Ju.GundamWars.BizMaster.MobileSSkills.Domain;

public interface IMobileSSkillPrimitive : IIdentify, IOrderable
{

    #region Primitives

    int SkillId { get; set; }
    string NameSuffix { get; set; }
    GradeType Grade { get; set; }

    #endregion

}
