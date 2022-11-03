using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class SupportSlotRepository : RepositoryBase<SupportSlot>
    {

        public SupportSlotRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<SupportSlot> SelectAll() =>
            Select(q => q.OrderBy(e => e.Order));

    }

}
