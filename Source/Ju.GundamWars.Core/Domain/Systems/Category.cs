using Ju.GundamWars.Const;

namespace Ju.GundamWars.Domain.Systems;

public record Category(CategoryType Type) : TypeRecord<CategoryType>(Type, Type.ToValue(), Type.ToText(), Type.ToIcon())
{
    public string Icon => General;
}
