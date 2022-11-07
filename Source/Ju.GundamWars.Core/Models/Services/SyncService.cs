using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Microsoft.Extensions.Options;
using System;
using System.Diagnostics;
using System.Reactive.Linq;
using System.Text.Json;
using Version = Ju.GundamWars.Models.Entities.Version;


namespace Ju.GundamWars.Models.Services
{

    public class SyncService : DisposableBindableBase
    {

        public SyncService(
            GwDbContext dbContext,
            PilotAbilityRepository pilotAbilityRepository,
            SupportSlotRepository supportSlotRepository,
            SupportBadgeRepository supportBadgeRepository,
            HttpGetService httpGetService,
            IOptions<SystemSetting> systemSetting)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            this.pilotAbilityRepository = pilotAbilityRepository ?? throw new ArgumentNullException(nameof(pilotAbilityRepository));
            this.supportSlotRepository = supportSlotRepository ?? throw new ArgumentNullException(nameof(supportSlotRepository));
            this.supportBadgeRepository = supportBadgeRepository ?? throw new ArgumentNullException(nameof(supportBadgeRepository));
            this.httpGetService = httpGetService ?? throw new ArgumentNullException(nameof(httpGetService));
            this.systemSetting = systemSetting?.Value ?? throw new ArgumentNullException(nameof(systemSetting));

            options = new JsonSerializerOptions { WriteIndented = true };
        }


        private readonly GwDbContext dbContext;
        private readonly PilotAbilityRepository pilotAbilityRepository;
        private readonly SupportSlotRepository supportSlotRepository;
        private readonly SupportBadgeRepository supportBadgeRepository;
        private readonly HttpGetService httpGetService;
        private readonly SystemSetting systemSetting;
        private readonly JsonSerializerOptions options;


        public bool Check() =>
            GetVersions().Any(r => r.Version?.Value != r.NewVersion.Value);

        public void Execute()
        {
            var results = GetVersions();
            if (results.All(v => v.Version?.Value == v.NewVersion.Value)) return;
            results.ForEach(v =>
            {
                if (v.Version?.Value != v.NewVersion.Value)
                {
                    switch (v.Name)
                    {
                        case "PilotAbility":
                            InsertOrUpdateEntities<PilotAbility, PilotAbilityRepository>(v, pilotAbilityRepository, (c, n) =>
                            {
                                c.Name = n.Name;
                                c.Rank = n.Rank;
                                c.Target1 = n.Target1;
                                c.Target2 = n.Target2;
                                c.Calc = n.Calc;
                                c.Value = n.Value;
                                c.Fraction = n.Fraction;
                                c.Order = n.Order;
                            });
                            break;
                        case "SupportSlot":
                            InsertOrUpdateEntities<SupportSlot, SupportSlotRepository>(v, supportSlotRepository, (c, n) =>
                            {
                                c.Name = n.Name;
                                c.Type = n.Type;
                                c.Target1 = n.Target1;
                                c.Target2 = n.Target2;
                                c.Calc = n.Calc;
                                c.Value = n.Value;
                                c.Fraction = n.Fraction;
                                c.Order = n.Order;
                            });
                            break;
                        case "SupportBadge":
                            InsertOrUpdateEntities<SupportBadge, SupportBadgeRepository>(v, supportBadgeRepository, (c, n) =>
                            {
                                c.Name = n.Name;
                                c.Type = n.Type;
                                c.Rank = n.Rank;
                                c.Target1 = n.Target1;
                                c.Target2 = n.Target2;
                                c.Calc = n.Calc;
                                c.Value = n.Value;
                                c.Fraction = n.Fraction;
                                c.Order = n.Order;
                            });
                            break;
                    }
                }
            });
        }

        private List<(string Name, Version? Version, Version NewVersion)> GetVersions()
        {
            var results = new List<(string, Version?, Version)>();
            var requestUri = $@"{systemSetting.DataRepositoryUri}Version.json";
            var remoteVersions = GetRemoteEntities<Version>(requestUri);
            remoteVersions.ForEach(n =>
            {
                results.Add((n.Name, dbContext.Versions.FirstOrDefault(c => c.Name == n.Name), n));
            });
            return results;
        }

        private void InsertOrUpdateEntities<TEntity, TRepository>((string Name, Version? Version, Version NewVersion) ver, TRepository repository, Action<TEntity, TEntity> copy)
            where TEntity : class, IEntity
            where TRepository : IRepository<TEntity>
        {
            var requestUri = $@"{systemSetting.DataRepositoryUri}{ver.Name}.json";
            var entities = GetRemoteEntities<TEntity>(requestUri);
            var inserts = entities.Where(n => repository.Entities.All(c => c.Id != n.Id)).ToList();
            var updates = entities.Where(n => repository.Entities.Any(c => c.Id == n.Id)).ToList();
            using var transaction = dbContext.Database.BeginTransaction();
            try
            {
                dbContext.Set<TEntity>().AddRange(inserts);
                updates.ForEach(n =>
                {
                    var current = repository.Entities.FirstOrDefault(c => c.Id == n.Id);
                    if (current != null)
                    {
                        copy(current, n);
                    }
                });
                if (ver.Version == null)
                {
                    dbContext.Versions.Add(ver.NewVersion);
                }
                else
                {
                    ver.Version.Value = ver.NewVersion.Value;
                }
#if DEBUG
                dbContext.ChangeTracker.DetectChanges();
                Debug.WriteLine(dbContext.ChangeTracker.DebugView.LongView);
#endif
                dbContext.SaveChanges();
                transaction.Commit();
                inserts.ForEach(e => repository.Entities.Add(e));
            }
            catch
            {
                transaction.Rollback();
            }
        }

        private List<TEntity> GetRemoteEntities<TEntity>(string requestUri)
            where TEntity : class, IEntity
        {
            return (httpGetService.TryGet(requestUri, out var remoteText)
                ? JsonSerializer.Deserialize<List<TEntity>>(remoteText, options)
                : null) ?? new List<TEntity>();
        }
    }

}
