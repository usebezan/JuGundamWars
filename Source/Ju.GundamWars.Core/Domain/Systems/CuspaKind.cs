using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record CuspaKind(CuspaKindType Type) : TypeRecord<CuspaKindType>(Type, Type.ToValue(), Type.ToText(), Type.ToGroup())
{
    public string Group => General;
}
