using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record Grade(GradeType Type) : TypeRecord<GradeType>(Type, Type.ToValue(), Type.ToText(), Type.ToColor())
{
    public string Color => General;
    public string GradeText => Name;
    public string GradeColor => General;
}
