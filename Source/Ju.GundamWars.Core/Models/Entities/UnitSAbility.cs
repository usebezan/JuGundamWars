using System;


namespace Ju.GundamWars.Models.Entities
{

    public class UnitSAbility : IEntity
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long EffectId { get; set; }
        public byte Rank { get; set; }
        public long Order { get; set; }

    }

}
