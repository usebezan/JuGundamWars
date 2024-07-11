using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizConst._.CuspaKinds.Domain;

public record CuspaKind(CuspaKindType Type) : TypeRecord<CuspaKindType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Group { get; } = Type.ToGroupText();
}
