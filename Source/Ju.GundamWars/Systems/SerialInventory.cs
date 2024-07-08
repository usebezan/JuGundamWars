using Ju.GundamWars.Domain.Systems.Entities;
using Ju.GundamWars.UseCase.Systems;

namespace Ju.GundamWars.Systems;

public class SerialInventory : GwObservableCollection<Serial>, ISerialInventory { }
