using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.CuspaKinds.Model;

public record CuspaKind(CuspaKindType Type) : TypeRecord<CuspaKindType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Group { get; } = Type.ToGroupText();
}
