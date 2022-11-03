using System;


namespace Ju.GundamWars.Models.Entities
{

    public class MobileSuitPair : IEntity
    {

        public long Id { get; set; }
        public long MobileSuit1Id { get; set; }
        public long MobileSuit2Id { get; set; }

    }

}
