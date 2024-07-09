using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster._.Categories.Domain;

public record Category(CategoryType Type) : TypeRecord<CategoryType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
}
