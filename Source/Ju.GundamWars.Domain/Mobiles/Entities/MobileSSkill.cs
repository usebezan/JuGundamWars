using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Mobiles.Entities;

public class MobileSSkill : IIdentify
{

    public int Id { get; set; }
    public string Group { get; set; } = null!;
    public string Name { get; set; } = null!;
    public GradeType Grade { get; set; } = GradeType.Grade4;
    public int Order { get; set; }

    public string GradeText => Grade.ToText();
    public string GradeColor => Grade.ToColor();

}
