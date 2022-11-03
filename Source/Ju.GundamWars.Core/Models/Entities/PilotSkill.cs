using System;


namespace Ju.GundamWars.Models.Entities
{

    public class PilotSkill : IEntity
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long EffectId { get; set; }
        public long Order { get; set; }

    }

}
