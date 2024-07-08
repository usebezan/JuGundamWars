using Ju.GundamWars.Domain.Mobiles;
using Ju.GundamWars.UseCase.Mobiles;

namespace Ju.GundamWars.Mobiles;

public class MobileInventory : GwNotifiableCollection<MobileSubject>, IMobileInventory { }
