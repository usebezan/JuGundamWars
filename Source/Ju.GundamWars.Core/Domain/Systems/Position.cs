using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record Position(PositionType Type) : TypeRecord<PositionType>(Type, Type.ToValue(), Type.ToText(), Type.ToIcon())
{
    public string Icon => General;
}
