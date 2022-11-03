using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using Microsoft.EntityFrameworkCore;
using System;


namespace Ju.GundamWars.Models.Repositories
{

    public class MobileArmorRepository : RepositoryBase<MobileArmor>
    {

        public MobileArmorRepository(GwDbContext dbContext) : base(dbContext) { }


        protected override List<MobileArmor> SelectAll() =>
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

    }

}
