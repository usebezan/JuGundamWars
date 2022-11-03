using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.ViewModels
{

    public class SupportDisplayViewModel : DisplayViewModelBase<SupportModel, SupportEntryViewModel>
    {

        public SupportDisplayViewModel(SupportModel model, MiscRepository miscRepository, WindowService windowService)
            : base(model, windowService)
        {
            Name = Model.Entity.ObserveProperty(e => e.Name).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            Unit = Model.Entity.ObserveProperty(e => e.Unit).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Grade = Model.Entity.ObserveProperty(e => e.Grade).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Tag = Model.Entity.ObserveProperty(e => e.Tag).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Memo = Model.Entity.ObserveProperty(e => e.Memo).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            UnitIconKind = Unit.Select(v => v.ToUnitType().ToIconKind()).ToReadOnlyReactivePropertySlim(UnitType.Unknown.ToIconKind()).AddTo(Disposables);
            TagType = Tag.Select(v => miscRepository.SupportTags.FirstOrDefault(e => e.Value == v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            HasMemo = Memo.Select(v => !string.IsNullOrEmpty(v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            Serial = Model.ObserveProperty(e => e.Serial).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            LimitedSerials = Model.LimitedSerials;
            SlotBadges = Model.SlotBadges;

            LimitedSerialsText = Model.ObserveProperty(e => e.LimitedSerialsText).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            SlotsText = Model.ObserveProperty(e => e.SlotsText).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            SlotsCount = Model.ObserveProperty(e => e.SlotsCount).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            BadgesText = Model.ObserveProperty(e => e.BadgesText).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            BadgesCount = Model.ObserveProperty(e => e.BadgesCount).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            Hp = Model.ObserveProperty(e => e.Hp).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            BeamAttack = Model.ObserveProperty(e => e.BeamAttack).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PhysicalAttack = Model.ObserveProperty(e => e.PhysicalAttack).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            BeamDefence = Model.ObserveProperty(e => e.BeamDefence).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            PhysicalDefence = Model.ObserveProperty(e => e.PhysicalDefence).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            CriticalRate = Model.ObserveProperty(e => e.CriticalRate).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            CriticalDamage = Model.ObserveProperty(e => e.CriticalDamage).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Accuracy = Model.ObserveProperty(e => e.Accuracy).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Evasion = Model.ObserveProperty(e => e.Evasion).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Mobility = Model.ObserveProperty(e => e.Mobility).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            EnRecovery = Model.ObserveProperty(e => e.EnRecovery).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            SuperPower = Model.ObserveProperty(e => e.SuperPower).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            AcePower = Model.ObserveProperty(e => e.AcePower).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            RecoveryPower = Model.ObserveProperty(e => e.RecoveryPower).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
        }


        public ReadOnlyReactivePropertySlim<string> Name { get; }
        public ReadOnlyReactivePropertySlim<byte> Unit { get; }
        public ReadOnlyReactivePropertySlim<byte> Grade { get; }
        public ReadOnlyReactivePropertySlim<byte> Tag { get; }
        public ReadOnlyReactivePropertySlim<string?> Memo { get; }

        public ReadOnlyReactivePropertySlim<string> UnitIconKind { get; }
        public ReadOnlyReactivePropertySlim<ByteType<SupportTagType>?> TagType { get; }
        public ReadOnlyReactivePropertySlim<bool> HasMemo { get; }

        public ReadOnlyReactivePropertySlim<Serial?> Serial { get; }
        public List<Wrapper<Serial?>> LimitedSerials { get; }
        public List<Wrapper<SupportSlot?, SupportBadge?>> SlotBadges { get; }

        public ReadOnlyReactivePropertySlim<string> LimitedSerialsText { get; }
        public ReadOnlyReactivePropertySlim<string> SlotsText { get; }
        public ReadOnlyReactivePropertySlim<int> SlotsCount { get; }
        public ReadOnlyReactivePropertySlim<string> BadgesText { get; }
        public ReadOnlyReactivePropertySlim<int> BadgesCount { get; }

        public ReadOnlyReactivePropertySlim<int> Hp { get; }
        public ReadOnlyReactivePropertySlim<int> BeamAttack { get; }
        public ReadOnlyReactivePropertySlim<int> PhysicalAttack { get; }
        public ReadOnlyReactivePropertySlim<int> BeamDefence { get; }
        public ReadOnlyReactivePropertySlim<int> PhysicalDefence { get; }
        public ReadOnlyReactivePropertySlim<int> CriticalRate { get; }
        public ReadOnlyReactivePropertySlim<int> CriticalDamage { get; }
        public ReadOnlyReactivePropertySlim<int> Accuracy { get; }
        public ReadOnlyReactivePropertySlim<int> Evasion { get; }
        public ReadOnlyReactivePropertySlim<int> Mobility { get; }
        public ReadOnlyReactivePropertySlim<int> EnRecovery { get; }
        public ReadOnlyReactivePropertySlim<int> SuperPower { get; }
        public ReadOnlyReactivePropertySlim<int> AcePower { get; }
        public ReadOnlyReactivePropertySlim<int> RecoveryPower { get; }


        protected override SupportEntryViewModel CreateEditViewModel() =>
            new(
                EntryType.Edit,
                Model,
                GetRequiredService<SupportSlotRepository>(),
                GetRequiredService<SupportBadgeRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

        protected override SupportEntryViewModel CreateCopyViewModel() =>
            new(
                EntryType.Copy,
                SupportModel.Create(Model.CloneEntity()),
                GetRequiredService<SupportSlotRepository>(),
                GetRequiredService<SupportBadgeRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

    }

}
