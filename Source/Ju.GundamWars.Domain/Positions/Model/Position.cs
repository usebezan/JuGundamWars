using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.Positions.Model;

public record Position(PositionType Type) : TypeRecord<PositionType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
}
