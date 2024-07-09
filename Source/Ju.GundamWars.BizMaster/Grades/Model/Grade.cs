using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Grades.Model;

public record Grade(GradeType Type) : TypeRecord<GradeType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Color { get; } = Type.ToColor();
    public string GradeText => Name;
    public string GradeColor => Color;
}
