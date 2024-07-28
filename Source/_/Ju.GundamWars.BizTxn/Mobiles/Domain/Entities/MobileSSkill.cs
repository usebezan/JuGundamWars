using Ju.GundamWars.Const;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Grades;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;

public class MobileSSkill : IIdentify
{

    public int Id { get; set; }
    public string Group { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public GradeType Grade { get; set; } = GradeType.Grade4;
    public int Order { get; set; }

    public string GradeText => Grade.ToText();
    public string GradeColor => Grade.ToColor();

}
