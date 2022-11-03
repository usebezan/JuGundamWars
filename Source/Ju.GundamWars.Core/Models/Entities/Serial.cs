using System;


namespace Ju.GundamWars.Models.Entities
{

    public class Serial : IEntity
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public long Order { get; set; }

    }

}
