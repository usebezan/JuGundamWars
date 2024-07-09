using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster._.CuspaKinds.Model;

public record CuspaKind(CuspaKindType Type) : TypeRecord<CuspaKindType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Group { get; } = Type.ToGroupText();
}
