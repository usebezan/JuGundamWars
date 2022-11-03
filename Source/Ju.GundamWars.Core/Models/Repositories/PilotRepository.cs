using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class PilotRepository : RepositoryBase<Pilot>
    {

        public PilotRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<Pilot> SelectAll() =>
            Select(q => q
                .Include(e => e.Serial)
                .Include(e => e.Skill)
                .Include(e => e.Ability1)
                .Include(e => e.Ability2)
                .Include(e => e.Ability3)
                .OrderBy(e => e.Name)
                .ThenBy(e => e.SerialId)
                .ThenBy(e => e.Id));

        public override Pilot CloneEntity(Pilot entity)
        {
            var clone = base.CloneEntity(entity);

            clone.Id = 0;

            clone.Serial = entity.Serial;
            clone.Skill = entity.Skill;
            clone.Ability1 = entity.Ability1;
            clone.Ability2 = entity.Ability2;
            clone.Ability3 = entity.Ability3;

            return clone;
        }

    }

}
