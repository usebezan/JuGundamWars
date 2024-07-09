using Ju.GundamWars.Domain.Common.Model;

namespace Ju.GundamWars.Domain.Categories.Model;

public record Category(CategoryType Type) : TypeRecord<CategoryType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
}
