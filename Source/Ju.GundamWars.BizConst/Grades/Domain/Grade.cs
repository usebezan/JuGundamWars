using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizConst.Grades.Domain;

public record Grade(GradeType Type) : TypeRecord<GradeType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Color { get; } = Type.ToColor();
    public bool ForMobile { get; } = Type.ForMobile();
    public bool ForMobileInitial { get; } = Type.ForMobileInitial();
    public bool ForPilot { get; } = Type.ForPilot();
    public bool ForSupport { get; } = Type.ForSupport();
    //public string GradeText => Name;
    //public string GradeColor => Color;
}
