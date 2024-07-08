using Ju.GundamWars.Const;
using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.System;

public record CuspaKind(CuspaKindType Type) : TypeRecord<CuspaKindType>(Type, Type.ToValue(), Type.ToText(), Type.ToGroup())
{
    public string Group => General;
}
