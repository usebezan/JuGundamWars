using System;


namespace Ju.GundamWars.Models.Entities
{

    public class Version : IEntity
    {

        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public int Value { get; set; }

    }

}
