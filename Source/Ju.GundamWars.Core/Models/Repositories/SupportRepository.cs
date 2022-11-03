using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class SupportRepository : RepositoryBase<Support>
    {

        public SupportRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<Support> SelectAll() =>
            Select(q => q
                .Include(e => e.Serial)
                .Include(e => e.LimitedSerial1)
                .Include(e => e.LimitedSerial2)
                .Include(e => e.LimitedSerial3)
                .Include(e => e.LimitedSerial4)
                .Include(e => e.LimitedSerial5)
                .Include(e => e.LimitedSerial6)
                .Include(e => e.Slot1)
                .Include(e => e.Badge1)
                .Include(e => e.Slot2)
                .Include(e => e.Badge2)
                .Include(e => e.Slot3)
                .Include(e => e.Badge3)
                .Include(e => e.Slot4)
                .Include(e => e.Badge4)
                .Include(e => e.Slot5)
                .Include(e => e.Badge5)
                .Include(e => e.Slot6)
                .Include(e => e.Badge6)
                .Include(e => e.Slot7)
                .Include(e => e.Badge7)
                .Include(e => e.Slot8)
                .Include(e => e.Badge8)
                .Include(e => e.Slot9)
                .Include(e => e.Badge9)
                .Include(e => e.Slot10)
                .Include(e => e.Badge10)
                .Include(e => e.Slot11)
                .Include(e => e.Badge11)
                .Include(e => e.Slot12)
                .Include(e => e.Badge12)
                .OrderBy(e => e.Name)
                .ThenBy(e => e.SerialId)
                .ThenBy(e => e.Id));

        public override Support CloneEntity(Support entity)
        {
            var clone = base.CloneEntity(entity);

            clone.Id = 0;

            clone.Serial = entity.Serial;
            clone.LimitedSerial1 = entity.LimitedSerial1;
            clone.LimitedSerial2 = entity.LimitedSerial2;
            clone.LimitedSerial3 = entity.LimitedSerial3;
            clone.LimitedSerial4 = entity.LimitedSerial4;
            clone.LimitedSerial5 = entity.LimitedSerial5;
            clone.LimitedSerial6 = entity.LimitedSerial6;
            clone.Slot1 = entity.Slot1;
            clone.Badge1 = entity.Badge1;
            clone.Slot2 = entity.Slot2;
            clone.Badge2 = entity.Badge2;
            clone.Slot3 = entity.Slot3;
            clone.Badge3 = entity.Badge3;
            clone.Slot4 = entity.Slot4;
            clone.Badge4 = entity.Badge4;
            clone.Slot5 = entity.Slot5;
            clone.Badge5 = entity.Badge5;
            clone.Slot6 = entity.Slot6;
            clone.Badge6 = entity.Badge6;
            clone.Slot7 = entity.Slot7;
            clone.Badge7 = entity.Badge7;
            clone.Slot8 = entity.Slot8;
            clone.Badge8 = entity.Badge8;
            clone.Slot9 = entity.Slot9;
            clone.Badge9 = entity.Badge9;
            clone.Slot10 = entity.Slot10;
            clone.Badge10 = entity.Badge10;
            clone.Slot11 = entity.Slot11;
            clone.Badge11 = entity.Badge11;
            clone.Slot12 = entity.Slot12;
            clone.Badge12 = entity.Badge12;

            return clone;
        }

    }

}
