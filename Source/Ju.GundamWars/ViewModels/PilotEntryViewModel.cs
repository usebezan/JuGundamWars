using Ju.GundamWars.Models;
using Ju.GundamWars.Models.Entities;
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

    public class PilotEntryViewModel : EntryViewModelBase<PilotModel, PilotOptionalViewModel>
    {

        public PilotEntryViewModel(EntryType type, PilotModel model, PilotOptionalViewModel optionalViewModel, WindowService windowService)
            : base(type, model, optionalViewModel, windowService)
        {
            Name = Model.Entity.ToReactivePropertyAsSynchronized(e => e.Name).AddTo(Disposables);
            Unit = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Unit).AddTo(Disposables);
            SkillText1 = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.SkillText1).AddTo(Disposables);
            SkillText2 = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.SkillText2).AddTo(Disposables);
            Grade = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Grade).AddTo(Disposables);
            Level = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Level).AddTo(Disposables);
            Shooting = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Shooting).AddTo(Disposables);
            Melee = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Melee).AddTo(Disposables);
            Accuracy = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Accuracy).AddTo(Disposables);
            Evasion = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Evasion).AddTo(Disposables);
            Awakened = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Awakened).AddTo(Disposables);
            Defense = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Defense).AddTo(Disposables);
            PracticedShooting = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PracticedShooting).AddTo(Disposables);
            PracticedMelee = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PracticedMelee).AddTo(Disposables);
            PracticedAccuracy = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PracticedAccuracy).AddTo(Disposables);
            PracticedEvasion = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PracticedEvasion).AddTo(Disposables);
            PracticedAwakened = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PracticedAwakened).AddTo(Disposables);
            PracticedDefense = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.PracticedDefense).AddTo(Disposables);
            SlotRank1 = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.SlotRank1).AddTo(Disposables);
            SlotRank2 = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.SlotRank2).AddTo(Disposables);
            SlotRank3 = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.SlotRank3).AddTo(Disposables);
            Tag = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Tag).AddTo(Disposables);
            Memo = Model.Entity.ToReactivePropertySlimAsSynchronized(e => e.Memo).AddTo(Disposables);

            Serial = Model.ToReactivePropertyAsSynchronized(e => e.Serial).AddTo(Disposables);
            Skill = Model.ToReactivePropertyAsSynchronized(e => e.Skill).AddTo(Disposables);
            Abilities = Model.Abilities;

            AbilityShooting = Model.ObserveProperty(e => e.AbilityShooting).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            AbilityMelee = Model.ObserveProperty(e => e.AbilityMelee).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            AbilityAccuracy = Model.ObserveProperty(e => e.AbilityAccuracy).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            AbilityEvasion = Model.ObserveProperty(e => e.AbilityEvasion).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            AbilityAwakened = Model.ObserveProperty(e => e.AbilityAwakened).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            AbilityDefense = Model.ObserveProperty(e => e.AbilityDefense).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            ActualShooting = Model.ObserveProperty(e => e.ActualShooting).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualMelee = Model.ObserveProperty(e => e.ActualMelee).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualAccuracy = Model.ObserveProperty(e => e.ActualAccuracy).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualEvasion = Model.ObserveProperty(e => e.ActualEvasion).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualAwakened = Model.ObserveProperty(e => e.ActualAwakened).ToReadOnlyReactivePropertySlim().AddTo(Disposables);
            ActualDefense = Model.ObserveProperty(e => e.ActualDefense).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            PracticedTotal = Model.ObserveProperty(e => e.PracticedTotal).ToReadOnlyReactivePropertySlim().AddTo(Disposables);

            HasErrors = new[]
                {
                    Name.SetValidateAttribute(() => Name).ObserveHasErrors,
                    Serial.SetValidateAttribute(() => Serial).ObserveHasErrors,
                    Skill.SetValidateAttribute(() => Skill).ObserveHasErrors,
                }
                .CombineLatestValuesAreAllFalse()
                .Select(v => !v)
                .ToReadOnlyReactivePropertySlim()
                .AddTo(Disposables);

            ResetPracticedCommand = new ReactiveCommand().WithSubscribe(Model.ResetPracticed).AddTo(Disposables);
        }


        public override string Title => Type switch
        {
            EntryType.Add => "Pilot Add",
            EntryType.Edit => "Pilot Edit",
            EntryType.Copy => "Pilot Copy",
            _ => "Pilot Entry",
        };
        public override string IconKind => "FaceMan";

        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<string> Name { get; }
        public ReactivePropertySlim<byte> Unit { get; }
        public ReactivePropertySlim<string?> SkillText1 { get; }
        public ReactivePropertySlim<string?> SkillText2 { get; }
        public ReactivePropertySlim<byte> Grade { get; }
        public ReactivePropertySlim<byte> Level { get; }
        public ReactivePropertySlim<int> Shooting { get; }
        public ReactivePropertySlim<int> Melee { get; }
        public ReactivePropertySlim<int> Accuracy { get; }
        public ReactivePropertySlim<int> Evasion { get; }
        public ReactivePropertySlim<int> Awakened { get; }
        public ReactivePropertySlim<int> Defense { get; }
        public ReactivePropertySlim<int> PracticedShooting { get; }
        public ReactivePropertySlim<int> PracticedMelee { get; }
        public ReactivePropertySlim<int> PracticedAccuracy { get; }
        public ReactivePropertySlim<int> PracticedEvasion { get; }
        public ReactivePropertySlim<int> PracticedAwakened { get; }
        public ReactivePropertySlim<int> PracticedDefense { get; }
        public ReactivePropertySlim<byte> SlotRank1 { get; }
        public ReactivePropertySlim<byte> SlotRank2 { get; }
        public ReactivePropertySlim<byte> SlotRank3 { get; }
        public ReactivePropertySlim<byte> Tag { get; }
        public ReactivePropertySlim<string?> Memo { get; }

        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<Serial?> Serial { get; }
        [Required(ErrorMessage = "Required.")]
        public ReactiveProperty<PilotSkill?> Skill { get; }
        public List<Wrapper<byte, PilotAbility?>> Abilities { get; }

        public ReadOnlyReactivePropertySlim<int> AbilityShooting { get; }
        public ReadOnlyReactivePropertySlim<int> AbilityMelee { get; }
        public ReadOnlyReactivePropertySlim<int> AbilityAccuracy { get; }
        public ReadOnlyReactivePropertySlim<int> AbilityEvasion { get; }
        public ReadOnlyReactivePropertySlim<int> AbilityAwakened { get; }
        public ReadOnlyReactivePropertySlim<int> AbilityDefense { get; }

        public ReadOnlyReactivePropertySlim<int> ActualShooting { get; }
        public ReadOnlyReactivePropertySlim<int> ActualMelee { get; }
        public ReadOnlyReactivePropertySlim<int> ActualAccuracy { get; }
        public ReadOnlyReactivePropertySlim<int> ActualEvasion { get; }
        public ReadOnlyReactivePropertySlim<int> ActualAwakened { get; }
        public ReadOnlyReactivePropertySlim<int> ActualDefense { get; }

        public ReadOnlyReactivePropertySlim<int> PracticedTotal { get; }

        public override ReadOnlyReactivePropertySlim<bool> HasErrors { get; }

        public ReactiveCommand ResetPracticedCommand { get; }

    }

}
