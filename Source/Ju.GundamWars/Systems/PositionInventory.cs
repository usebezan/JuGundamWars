using Ju.GundamWars.Domain.Systems;
using Ju.GundamWars.UseCase.Systems;

namespace Ju.GundamWars.Systems;

public class PositionInventory : GwObservableCollection<Position>, IPositionInventory { }
