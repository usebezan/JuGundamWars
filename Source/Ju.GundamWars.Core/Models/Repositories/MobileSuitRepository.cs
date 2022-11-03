using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class MobileSuitRepository : RepositoryBase<MobileSuit>
    {

        public MobileSuitRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<MobileSuit> SelectAll() =>
            Select(q => q
                .Include(e => e.Serial)
                .Include(e => e.SubSerial1)
                .Include(e => e.SubSerial2)
                .Include(e => e.SubSerial3)
                .Include(e => e.SubSerial4)
                .Include(e => e.Pilot)
                .Include(e => e.Support1)
                .Include(e => e.Support2)
                .Include(e => e.Support3)
                .Include(e => e.Support4)
                .Include(e => e.SAbility1)
                .Include(e => e.SAbility2)
                .Include(e => e.SAbility3)
                .Include(e => e.SAbility4)
                .OrderBy(e => e.Name)
                .ThenBy(e => e.SerialId)
                .ThenBy(e => e.Id));


        public void Insert(MobileSuit first, MobileSuit second)
        {
            Execute(db =>
            {
                db.Set<MobileSuit>().Add(first);
                db.Set<MobileSuit>().Add(second);
                db.Set<MobileSuitPair>().Add(new MobileSuitPair() { MobileSuit1Id = first.Id, MobileSuit2Id = second.Id, });
            });
            Entities.Add(first);
            Entities.Add(second);
        }

        public void Delete(MobileSuit first, MobileSuit second)
        {
            Execute(db =>
            {
                db.Set<MobileSuit>().Remove(first);
                db.Set<MobileSuit>().Remove(second);
                var pair = db.Set<MobileSuitPair>().FirstOrDefault(e => e.MobileSuit1Id == first.Id || e.MobileSuit2Id == first.Id || e.MobileSuit1Id == second.Id || e.MobileSuit2Id == second.Id);
                if (pair != null)
                {
                    db.Set<MobileSuitPair>().Remove(pair);
                }
            });
            Entities.Remove(first);
            Entities.Remove(second);
        }

        public void Reload(MobileSuit first, MobileSuit second)
        {
            Reload(first);
            Reload(second);
        }

        public bool IsDirty(MobileSuit first, MobileSuit second) =>
            IsDirty(first) || IsDirty(second);

        public virtual (MobileSuit First, MobileSuit Second) CloneEntity(MobileSuit first, MobileSuit second) =>
            (CloneEntity(first), CloneEntity(second));


        public bool IsPaired(MobileSuit entity) =>
            DbContext.Set<MobileSuitPair>().Any(e => e.MobileSuit1Id == entity.Id || e.MobileSuit2Id == entity.Id);

        public (MobileSuit First, MobileSuit Second)? GetPair(MobileSuit entity)
        {
            var firstId = DbContext.Set<MobileSuitPair>().FirstOrDefault(e => e.MobileSuit2Id == entity.Id)?.MobileSuit1Id;
            if (firstId != null)
            {
                var first = Entities.FirstOrDefault(e => e.Id == firstId) ?? new MobileSuit();
                return (first, entity);
            }
            var secondId = DbContext.Set<MobileSuitPair>().FirstOrDefault(e => e.MobileSuit1Id == entity.Id)?.MobileSuit2Id;
            if (secondId != null)
            {
                var second = Entities.FirstOrDefault(e => e.Id == secondId) ?? new MobileSuit();
                return (entity, second);
            }
            return null;
        }

    }

}
