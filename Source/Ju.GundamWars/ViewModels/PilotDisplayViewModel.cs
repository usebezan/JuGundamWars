using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Linq;
using System.Reactive.Linq;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.ViewModels
{

    public class PilotDisplayViewModel : DisplayViewModelBase<PilotModel, PilotEntryViewModel>
    {

        public PilotDisplayViewModel(PilotModel model, MiscRepository miscRepository, WindowService windowService)
            : base(model, windowService)
        {
            Name = Model.Entity.ObserveProperty(e => e.Name).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            Unit = Model.Entity.ObserveProperty(e => e.Unit).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            SkillText1 = Model.Entity.ObserveProperty(e => e.SkillText1).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            SkillText2 = Model.Entity.ObserveProperty(e => e.SkillText2).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Grade = Model.Entity.ObserveProperty(e => e.Grade).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Level = Model.Entity.ObserveProperty(e => e.Level).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PracticedShooting = Model.Entity.ObserveProperty(e => e.PracticedShooting).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PracticedMelee = Model.Entity.ObserveProperty(e => e.PracticedMelee).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PracticedAccuracy = Model.Entity.ObserveProperty(e => e.PracticedAccuracy).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PracticedEvasion = Model.Entity.ObserveProperty(e => e.PracticedEvasion).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PracticedAwakened = Model.Entity.ObserveProperty(e => e.PracticedAwakened).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PracticedDefense = Model.Entity.ObserveProperty(e => e.PracticedDefense).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            SlotRank1 = Model.Entity.ObserveProperty(e => e.SlotRank1).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            SlotRank2 = Model.Entity.ObserveProperty(e => e.SlotRank2).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            SlotRank3 = Model.Entity.ObserveProperty(e => e.SlotRank3).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Tag = Model.Entity.ObserveProperty(e => e.Tag).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Memo = Model.Entity.ObserveProperty(e => e.Memo).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            UnitIconKind = Unit.Select(v => v.ToUnitType().ToIconKind()).ToReadOnlyReactivePropertySlim(UnitType.Unknown.ToIconKind()).AddTo(Disposables);
            TagType = Tag.Select(v => miscRepository.PilotTags.FirstOrDefault(t => t.Value == v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            HasMemo = Memo.Select(v => !string.IsNullOrEmpty(v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            Serial = Model.ObserveProperty(e => e.Serial).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Skill = Model.ObserveProperty(e => e.Skill).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Ability1 = Model.ObserveProperty(e => e.Ability1).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Ability2 = Model.ObserveProperty(e => e.Ability2).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Ability3 = Model.ObserveProperty(e => e.Ability3).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            ActualShooting = Model.ObserveProperty(e => e.ActualShooting).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualMelee = Model.ObserveProperty(e => e.ActualMelee).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualAccuracy = Model.ObserveProperty(e => e.ActualAccuracy).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualEvasion = Model.ObserveProperty(e => e.ActualEvasion).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualAwakened = Model.ObserveProperty(e => e.ActualAwakened).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualDefense = Model.ObserveProperty(e => e.ActualDefense).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            PracticedTotal = Model.ObserveProperty(e => e.PracticedTotal).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
        }


        public ReadOnlyReactivePropertySlim<string> Name { get; }
        public ReadOnlyReactivePropertySlim<byte> Unit { get; }
        public ReadOnlyReactivePropertySlim<string?> SkillText1 { get; }
        public ReadOnlyReactivePropertySlim<string?> SkillText2 { get; }
        public ReadOnlyReactivePropertySlim<byte> Grade { get; }
        public ReadOnlyReactivePropertySlim<byte> Level { get; }
        public ReadOnlyReactivePropertySlim<int> PracticedShooting { get; }
        public ReadOnlyReactivePropertySlim<int> PracticedMelee { get; }
        public ReadOnlyReactivePropertySlim<int> PracticedAccuracy { get; }
        public ReadOnlyReactivePropertySlim<int> PracticedEvasion { get; }
        public ReadOnlyReactivePropertySlim<int> PracticedAwakened { get; }
        public ReadOnlyReactivePropertySlim<int> PracticedDefense { get; }
        public ReadOnlyReactivePropertySlim<byte> SlotRank1 { get; }
        public ReadOnlyReactivePropertySlim<byte> SlotRank2 { get; }
        public ReadOnlyReactivePropertySlim<byte> SlotRank3 { get; }
        public ReadOnlyReactivePropertySlim<byte> Tag { get; }
        public ReadOnlyReactivePropertySlim<string?> Memo { get; }

        public ReadOnlyReactivePropertySlim<string> UnitIconKind { get; }
        public ReadOnlyReactivePropertySlim<ByteType<PilotTagType>?> TagType { get; }
        public ReadOnlyReactivePropertySlim<bool> HasMemo { get; }

        public ReadOnlyReactivePropertySlim<Serial?> Serial { get; }
        public ReadOnlyReactivePropertySlim<PilotSkill?> Skill { get; }
        public ReadOnlyReactivePropertySlim<PilotAbility?> Ability1 { get; }
        public ReadOnlyReactivePropertySlim<PilotAbility?> Ability2 { get; }
        public ReadOnlyReactivePropertySlim<PilotAbility?> Ability3 { get; }

        public ReadOnlyReactivePropertySlim<int> ActualShooting { get; }
        public ReadOnlyReactivePropertySlim<int> ActualMelee { get; }
        public ReadOnlyReactivePropertySlim<int> ActualAccuracy { get; }
        public ReadOnlyReactivePropertySlim<int> ActualEvasion { get; }
        public ReadOnlyReactivePropertySlim<int> ActualAwakened { get; }
        public ReadOnlyReactivePropertySlim<int> ActualDefense { get; }

        public ReadOnlyReactivePropertySlim<int> PracticedTotal { get; }


        protected override PilotEntryViewModel CreateEditViewModel() =>
            new(
                EntryType.Edit,
                Model,
                GetRequiredService<PilotSkillRepository>(),
                GetRequiredService<PilotAbilityRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

        protected override PilotEntryViewModel CreateCopyViewModel() =>
            new(
                EntryType.Copy,
                PilotModel.Create(Model.CloneEntity()),
                GetRequiredService<PilotSkillRepository>(),
                GetRequiredService<PilotAbilityRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

    }

}
