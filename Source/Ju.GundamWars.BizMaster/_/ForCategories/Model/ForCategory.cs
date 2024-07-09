using Ju.GundamWars.BizMaster._.Categories;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.BizMaster._.ForCategories.Model;

public record ForCategory(CategoryType Type) : TypeRecord<CategoryType, byte>(Type, Type.ToValue(), Type.ToText())
{
    public string Icon { get; } = Type.ToIcon();
    public bool ForCoMobile => Type == CategoryType.MobileSuit || Type == CategoryType.MobileArmor;
    public bool ForCuspa => Type == CategoryType.MobileSuit || Type == CategoryType.Battleship;
    public bool ForMobile => Type == CategoryType.MobileSuit || Type == CategoryType.MobileArmor;
    public bool ForPilot => Type == CategoryType.MobileSuit || Type == CategoryType.MobileArmor;
    public bool ForSupport => Type == CategoryType.MobileSuit || Type == CategoryType.MobileArmor;
}
