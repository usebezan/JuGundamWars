using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Services;
using System;
using System.Text.Json;


namespace Ju.GundamWars.Utilities.DataSaver
{

    public class Saver
    {

        public Saver(GwDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }


        private readonly GwDbContext dbContext;


        public void Run()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            File.WriteAllText("Serial.json", JsonSerializer.Serialize(dbContext.Set<Serial>().ToList(), options));
            File.WriteAllText("PilotSkill.json", JsonSerializer.Serialize(dbContext.Set<PilotSkill>().ToList(), options));
            File.WriteAllText("PilotAbility.json", JsonSerializer.Serialize(dbContext.Set<PilotAbility>().ToList(), options));
            File.WriteAllText("SupportSlot.json", JsonSerializer.Serialize(dbContext.Set<SupportSlot>().ToList(), options));
            File.WriteAllText("SupportBadge.json", JsonSerializer.Serialize(dbContext.Set<SupportBadge>().ToList(), options));
            File.WriteAllText("Version.json", JsonSerializer.Serialize(dbContext.Versions.ToList(), options));
        }

    }

}
