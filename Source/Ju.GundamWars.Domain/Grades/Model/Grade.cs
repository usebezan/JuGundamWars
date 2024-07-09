using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.Grades.Model;

public record Grade(GradeType Type) : TypeRecord<GradeType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Color { get; } = Type.ToColor();
    public string GradeText => Name;
    public string GradeColor => Color;
}
