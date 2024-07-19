using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Share._TODO.Categories.Domain;

public record Category(CategoryType Type) : TypeRecord<CategoryType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
}
