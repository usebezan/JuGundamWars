using Ju.GundamWars.Domain.CoMobiles;
using Ju.GundamWars.UseCase.CoMobiles;

namespace Ju.GundamWars.CoMobiles;

public class CoMobileInventory : GwNotifiableCollection<CoMobileSubject>, ICoMobileInventory { }
