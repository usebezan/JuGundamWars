using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class SerialRepository : RepositoryBase<Serial>
    {

        public SerialRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<Serial> SelectAll() =>
            Select(q => q.OrderBy(e => e.Order));

    }

}
