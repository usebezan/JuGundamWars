using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;

namespace Ju.GundamWars.Systems;

public class BoostInventory : GwObservableCollection<Boost>, IBoostInventory { }
