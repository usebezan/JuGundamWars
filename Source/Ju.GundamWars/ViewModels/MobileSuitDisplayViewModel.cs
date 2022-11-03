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

    public class MobileSuitDisplayViewModel : DisplayViewModelBase<MobileSuitModel, MobileSuitEntryViewModel>
    {

        public MobileSuitDisplayViewModel(MobileSuitModel model, MiscRepository miscRepository, WindowService windowService)
            : base(model, windowService)
        {
            Name = Model.Entity.ObserveProperty(e => e.Name).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            InitialGrade = Model.Entity.ObserveProperty(e => e.InitialGrade).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Grade = Model.Entity.ObserveProperty(e => e.Grade).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Tag = Model.Entity.ObserveProperty(e => e.Tag).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            Memo = Model.Entity.ObserveProperty(e => e.Memo).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            Serial = Model.Entity.ObserveProperty(e => e.Serial).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            //LimitedSerials = Model.LimitedSerials;
            //SlotBadges = Model.SlotBadges;

            InitialGradeType = InitialGrade.Select(v => miscRepository.Grades.FirstOrDefault(e => e.Value == v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            GradeType = Grade.Select(v => miscRepository.Grades.FirstOrDefault(e => e.Value == v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            TagType = Tag.Select(v => miscRepository.MobileSuitTags.FirstOrDefault(e => e.Value == v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            HasMemo = Memo.Select(v => !string.IsNullOrEmpty(v)).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            SubSerialsText = Model.ObserveProperty(e => e.SubSerialsText).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);
            SAbilitysText = Model.ObserveProperty(e => e.SAbilitysText).ToReadOnlyReactivePropertySlim("").AddTo(Disposables);

            //Hp = Model.ObserveProperty(e => e.Hp).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //BeamAttack = Model.ObserveProperty(e => e.BeamAttack).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //PhysicalAttack = Model.ObserveProperty(e => e.PhysicalAttack).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //BeamDefence = Model.ObserveProperty(e => e.BeamDefence).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //PhysicalDefence = Model.ObserveProperty(e => e.PhysicalDefence).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //CriticalRate = Model.ObserveProperty(e => e.CriticalRate).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //CriticalDamage = Model.ObserveProperty(e => e.CriticalDamage).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //Accuracy = Model.ObserveProperty(e => e.Accuracy).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //Evasion = Model.ObserveProperty(e => e.Evasion).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //Mobility = Model.ObserveProperty(e => e.Mobility).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //EnRecovery = Model.ObserveProperty(e => e.EnRecovery).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //SuperMove = Model.ObserveProperty(e => e.SuperMove).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //AceMove = Model.ObserveProperty(e => e.AceMove).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            //RecoveryPower = Model.ObserveProperty(e => e.RecoveryPower).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            MoveCommand = new ReactiveCommand().WithSubscribe(Move).AddTo(Disposables);
        }


        public ReadOnlyReactivePropertySlim<string> Name { get; }
        public ReadOnlyReactivePropertySlim<byte> InitialGrade { get; }
        public ReadOnlyReactivePropertySlim<byte> Grade { get; }
        public ReadOnlyReactivePropertySlim<byte> Tag { get; }
        public ReadOnlyReactivePropertySlim<string?> Memo { get; }

        public ReadOnlyReactivePropertySlim<Serial?> Serial { get; }

        //public List<Wrapper<Serial?>> LimitedSerials { get; }
        //public List<Wrapper<MobileSuitSlot?, MobileSuitBadge?>> SlotBadges { get; }

        public ReadOnlyReactivePropertySlim<GradeType?> InitialGradeType { get; }
        public ReadOnlyReactivePropertySlim<GradeType?> GradeType { get; }
        public ReadOnlyReactivePropertySlim<ByteType<MobileSuitTagType>?> TagType { get; }
        public ReadOnlyReactivePropertySlim<bool> HasMemo { get; }

        public ReadOnlyReactivePropertySlim<string> SubSerialsText { get; }
        public ReadOnlyReactivePropertySlim<string> SAbilitysText { get; }

        //public ReadOnlyReactivePropertySlim<int> Hp { get; }
        //public ReadOnlyReactivePropertySlim<int> BeamAttack { get; }
        //public ReadOnlyReactivePropertySlim<int> PhysicalAttack { get; }
        //public ReadOnlyReactivePropertySlim<int> BeamDefence { get; }
        //public ReadOnlyReactivePropertySlim<int> PhysicalDefence { get; }
        //public ReadOnlyReactivePropertySlim<int> CriticalRate { get; }
        //public ReadOnlyReactivePropertySlim<int> CriticalDamage { get; }
        //public ReadOnlyReactivePropertySlim<int> Accuracy { get; }
        //public ReadOnlyReactivePropertySlim<int> Evasion { get; }
        //public ReadOnlyReactivePropertySlim<int> Mobility { get; }
        //public ReadOnlyReactivePropertySlim<int> EnRecovery { get; }
        //public ReadOnlyReactivePropertySlim<int> SuperMove { get; }
        //public ReadOnlyReactivePropertySlim<int> AceMove { get; }
        //public ReadOnlyReactivePropertySlim<int> RecoveryPower { get; }

        public ReactiveCommand MoveCommand { get; }


        private void Move()
        {

        }

        protected override MobileSuitEntryViewModel CreateEditViewModel() =>
            new(
                EntryType.Edit,
                Model,
                GetRequiredService<PilotModelRepository>(),
                GetRequiredService<SupportModelRepository>(),
                GetRequiredService<UnitSAbilityRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

        protected override MobileSuitEntryViewModel CreateCopyViewModel() =>
            new(
                EntryType.Copy,
                MobileSuitModel.Create(Model.CloneEntity()),
                GetRequiredService<PilotModelRepository>(),
                GetRequiredService<SupportModelRepository>(),
                GetRequiredService<UnitSAbilityRepository>(),
                GetRequiredService<SerialRepository>(),
                GetRequiredService<MiscRepository>(),
                WindowService);

    }

}
