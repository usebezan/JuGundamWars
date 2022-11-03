using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class UnitSAbilityRepository : RepositoryBase<UnitSAbility>
    {

        public UnitSAbilityRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<UnitSAbility> SelectAll() =>
            Select(q => q.OrderBy(e => e.Order));

    }

}
