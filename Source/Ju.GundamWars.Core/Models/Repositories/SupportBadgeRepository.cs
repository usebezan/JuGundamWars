using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class SupportBadgeRepository : RepositoryBase<SupportBadge>
    {

        public SupportBadgeRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<SupportBadge> SelectAll() =>
            Select(q => q.OrderBy(e => e.Order));

    }

}
