using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class PilotSkillRepository : RepositoryBase<PilotSkill>
    {

        public PilotSkillRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<PilotSkill> SelectAll() =>
            Select(q => q.OrderBy(e => e.Order));

    }

}
