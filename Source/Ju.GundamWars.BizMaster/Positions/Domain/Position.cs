using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster.Positions.Domain;

public record Position(PositionType Type) : TypeRecord<PositionType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
}
