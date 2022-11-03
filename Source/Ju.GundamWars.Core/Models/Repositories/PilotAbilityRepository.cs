using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class PilotAbilityRepository : RepositoryBase<PilotAbility>
    {

        public PilotAbilityRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<PilotAbility> SelectAll() =>
            Select(q => q.OrderBy(e => e.Order));

    }

}
