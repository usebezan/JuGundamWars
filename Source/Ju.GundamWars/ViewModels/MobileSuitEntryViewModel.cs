using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Ju.GundamWars.Models.Services;
using Reactive.Bindings;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reactive.Linq;


namespace Ju.GundamWars.ViewModels
{

    public class MobileSuitEntryViewModel : EntryViewModelBase<MobileSuitModel, MobileSuitOptionalViewModel>
    {

        public MobileSuitEntryViewModel(EntryType type, MobileSuitModel model, MobileSuitOptionalViewModel optionalViewModel, PilotModelRepository pilotModelRepository, SupportModelRepository supportModelRepository, UnitSAbilityRepository unitAbilityRepository, SerialRepository serialRepository, MiscRepository miscRepository, WindowService windowService)
            : base(type, model, optionalViewModel, windowService)
        {
            Name = Model.Entity.ToReactivePropertyAsSynchronized(e => e.Name).AddTo(Disposables);
            InitialGrade = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.InitialGrade).AddTo(Disposables);
            Role = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Role).AddTo(Disposables);
            Grade = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Grade).AddTo(Disposables);
            Level = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Level).AddTo(Disposables);

            Hp = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Hp).AddTo(Disposables);
            BeamAttack = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.BeamAttack).AddTo(Disposables);
            PhysicalAttack = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PhysicalAttack).AddTo(Disposables);
            BeamDefence = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.BeamDefence).AddTo(Disposables);
            PhysicalDefence = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PhysicalDefence).AddTo(Disposables);
            CriticalRate = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CriticalRate).AddTo(Disposables);
            CriticalDamage = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CriticalDamage).AddTo(Disposables);
            Accuracy = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Accuracy).AddTo(Disposables);
            Evasion = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Evasion).AddTo(Disposables);
            Mobility = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Mobility).AddTo(Disposables);
            SuperEnRecovery = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.SuperEnRecovery).AddTo(Disposables);
            AceEnRecovery = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.AceEnRecovery).AddTo(Disposables);
            RemodelingHp = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingHp).AddTo(Disposables);
            RemodelingBeamAttack = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingBeamAttack).AddTo(Disposables);
            RemodelingPhysicalAttack = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingPhysicalAttack).AddTo(Disposables);
            RemodelingBeamDefence = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingBeamDefence).AddTo(Disposables);
            RemodelingPhysicalDefence = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingPhysicalDefence).AddTo(Disposables);
            RemodelingCriticalRate = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingCriticalRate).AddTo(Disposables);
            RemodelingCriticalDamage = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingCriticalDamage).AddTo(Disposables);
            RemodelingAccuracy = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingAccuracy).AddTo(Disposables);
            RemodelingEvasion = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingEvasion).AddTo(Disposables);
            RemodelingMobility = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingMobility).AddTo(Disposables);
            RemodelingEnRecovery = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.RemodelingEnRecovery).AddTo(Disposables);
            CustomHp = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomHp).AddTo(Disposables);
            CustomBeamAttack = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomBeamAttack).AddTo(Disposables);
            CustomPhysicalAttack = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomPhysicalAttack).AddTo(Disposables);
            CustomBeamDefence = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomBeamDefence).AddTo(Disposables);
            CustomPhysicalDefence = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomPhysicalDefence).AddTo(Disposables);
            CustomCriticalRate = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomCriticalRate).AddTo(Disposables);
            CustomCriticalDamage = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomCriticalDamage).AddTo(Disposables);
            CustomAccuracy = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomAccuracy).AddTo(Disposables);
            CustomEvasion = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomEvasion).AddTo(Disposables);
            CustomMobility = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomMobility).AddTo(Disposables);
            CustomEnRecovery = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.CustomEnRecovery).AddTo(Disposables);
            PilotHp = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotHp).AddTo(Disposables);
            PilotBeamAttack = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotBeamAttack).AddTo(Disposables);
            PilotPhysicalAttack = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotPhysicalAttack).AddTo(Disposables);
            PilotBeamDefence = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotBeamDefence).AddTo(Disposables);
            PilotPhysicalDefence = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotPhysicalDefence).AddTo(Disposables);
            PilotCriticalRate = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotCriticalRate).AddTo(Disposables);
            PilotCriticalDamage = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotCriticalDamage).AddTo(Disposables);
            PilotAccuracy = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotAccuracy).AddTo(Disposables);
            PilotEvasion = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotEvasion).AddTo(Disposables);
            PilotMobility = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotMobility).AddTo(Disposables);
            PilotEnRecovery = Model.ToReactivePropertySlimAsSynchronized(e => e.PilotEnRecovery).AddTo(Disposables);
            SupportHp = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportHp).AddTo(Disposables);
            SupportBeamAttack = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportBeamAttack).AddTo(Disposables);
            SupportPhysicalAttack = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportPhysicalAttack).AddTo(Disposables);
            SupportBeamDefence = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportBeamDefence).AddTo(Disposables);
            SupportPhysicalDefence = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportPhysicalDefence).AddTo(Disposables);
            SupportCriticalRate = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportCriticalRate).AddTo(Disposables);
            SupportCriticalDamage = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportCriticalDamage).AddTo(Disposables);
            SupportAccuracy = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportAccuracy).AddTo(Disposables);
            SupportEvasion = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportEvasion).AddTo(Disposables);
            SupportMobility = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportMobility).AddTo(Disposables);
            SupportEnRecovery = Model.ToReactivePropertySlimAsSynchronized(e => e.SupportEnRecovery).AddTo(Disposables);

            Tag = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Tag).AddTo(Disposables);
            Memo = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Memo).AddTo(Disposables);

            Serial = Model.Entity.ToReactivePropertyAsSynchronized(e => e.Serial).AddTo(Disposables);
            SubSerials = Model.SubSerials;
            Pilot = Model.ToReactivePropertySlimAsSynchronized(e => e.Pilot).AddTo(Disposables);
            Supports = Model.Supports;

            //Enhancements = Model.Enhancements;

            HasErrors = new[]
                {
                    Name.SetValidateAttribute(() => Name).ObserveHasErrors,
                    Serial.SetValidateAttribute(() => Serial).ObserveHasErrors,
                }
                .CombineLatestValuesAreAllFalse()
                .Select(v => !v)
                .ToReadOnlyReactivePropertySlim()
                .AddTo(Disposables);
        }


        public override string Title => Type switch
        {
            EntryType.Add => "Mobile Suit Add",
            EntryType.Edit => "Mobile Suit Edit",
            EntryType.Copy => "Mobile Suit Copy",
            _ => "Mobile Suit Entry",
        };
        public override string IconKind => "Robot";

        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<string> Name { get; }
        public ReactivePropertySlim<byte> InitialGrade { get; }
        public ReactivePropertySlim<byte> Role { get; }
        public ReactivePropertySlim<byte> Grade { get; }
        public ReactivePropertySlim<byte> Level { get; }

        public ReactivePropertySlim<int> Hp { get; }
        public ReactivePropertySlim<int> BeamAttack { get; }
        public ReactivePropertySlim<int> PhysicalAttack { get; }
        public ReactivePropertySlim<int> BeamDefence { get; }
        public ReactivePropertySlim<int> PhysicalDefence { get; }
        public ReactivePropertySlim<int> CriticalRate { get; }
        public ReactivePropertySlim<int> CriticalDamage { get; }
        public ReactivePropertySlim<int> Accuracy { get; }
        public ReactivePropertySlim<int> Evasion { get; }
        public ReactivePropertySlim<int> Mobility { get; }
        public ReactivePropertySlim<int> SuperEnRecovery { get; }
        public ReactivePropertySlim<int> AceEnRecovery { get; }
        public ReactivePropertySlim<int> RemodelingHp { get; }
        public ReactivePropertySlim<int> RemodelingBeamAttack { get; }
        public ReactivePropertySlim<int> RemodelingPhysicalAttack { get; }
        public ReactivePropertySlim<int> RemodelingBeamDefence { get; }
        public ReactivePropertySlim<int> RemodelingPhysicalDefence { get; }
        public ReactivePropertySlim<int> RemodelingCriticalRate { get; }
        public ReactivePropertySlim<int> RemodelingCriticalDamage { get; }
        public ReactivePropertySlim<int> RemodelingAccuracy { get; }
        public ReactivePropertySlim<int> RemodelingEvasion { get; }
        public ReactivePropertySlim<int> RemodelingMobility { get; }
        public ReactivePropertySlim<int> RemodelingEnRecovery { get; }
        public ReactivePropertySlim<int> CustomHp { get; }
        public ReactivePropertySlim<int> CustomBeamAttack { get; }
        public ReactivePropertySlim<int> CustomPhysicalAttack { get; }
        public ReactivePropertySlim<int> CustomBeamDefence { get; }
        public ReactivePropertySlim<int> CustomPhysicalDefence { get; }
        public ReactivePropertySlim<int> CustomCriticalRate { get; }
        public ReactivePropertySlim<int> CustomCriticalDamage { get; }
        public ReactivePropertySlim<int> CustomAccuracy { get; }
        public ReactivePropertySlim<int> CustomEvasion { get; }
        public ReactivePropertySlim<int> CustomMobility { get; }
        public ReactivePropertySlim<int> CustomEnRecovery { get; }
        public ReactivePropertySlim<int> PilotHp { get; }
        public ReactivePropertySlim<int> PilotBeamAttack { get; }
        public ReactivePropertySlim<int> PilotPhysicalAttack { get; }
        public ReactivePropertySlim<int> PilotBeamDefence { get; }
        public ReactivePropertySlim<int> PilotPhysicalDefence { get; }
        public ReactivePropertySlim<int> PilotCriticalRate { get; }
        public ReactivePropertySlim<int> PilotCriticalDamage { get; }
        public ReactivePropertySlim<int> PilotAccuracy { get; }
        public ReactivePropertySlim<int> PilotEvasion { get; }
        public ReactivePropertySlim<int> PilotMobility { get; }
        public ReactivePropertySlim<int> PilotEnRecovery { get; }
        public ReactivePropertySlim<int> SupportHp { get; }
        public ReactivePropertySlim<int> SupportBeamAttack { get; }
        public ReactivePropertySlim<int> SupportPhysicalAttack { get; }
        public ReactivePropertySlim<int> SupportBeamDefence { get; }
        public ReactivePropertySlim<int> SupportPhysicalDefence { get; }
        public ReactivePropertySlim<int> SupportCriticalRate { get; }
        public ReactivePropertySlim<int> SupportCriticalDamage { get; }
        public ReactivePropertySlim<int> SupportAccuracy { get; }
        public ReactivePropertySlim<int> SupportEvasion { get; }
        public ReactivePropertySlim<int> SupportMobility { get; }
        public ReactivePropertySlim<int> SupportEnRecovery { get; }

        public ReactivePropertySlim<byte> Tag { get; }
        public ReactivePropertySlim<string?> Memo { get; }

        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<Serial?> Serial { get; }
        public List<Wrapper<Serial?>> SubSerials { get; }
        public ReactivePropertySlim<PilotModel?> Pilot { get; }
        public List<Wrapper<SupportModel?>> Supports { get; }


        //public ObservableCollection<KeyValuePair<string, string>> Enhancements { get; }

        public override ReadOnlyReactivePropertySlim<bool> HasErrors { get; }

    }

}
