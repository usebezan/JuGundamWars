using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Share.Units.Domain;

public record Unit(UnitType Type) : TypeRecord<UnitType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
}
