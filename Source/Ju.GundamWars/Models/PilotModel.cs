using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Ju.GundamWars.Models
{

    public class PilotModel : ModelBase<Pilot, PilotRepository>
    {

        public PilotModel(Pilot entity, PilotRepository repository)
            : base(entity, repository)
        {
            isIdle = false;

            Abilities = new()
            {
                new(() => Entity.SlotRank1, v => Entity.SlotRank1 = v, () => Ability1, v => Ability1 = v),
                new(() => Entity.SlotRank2, v => Entity.SlotRank2 = v, () => Ability2, v => Ability2 = v),
                new(() => Entity.SlotRank3, v => Entity.SlotRank3 = v, () => Ability3, v => Ability3 = v),
            };

            Enhancements = new();

            _ = Entity.PropertyChanged.Subscribe(n =>
            {
                switch (n)
                {
                    case "Shooting":
                    case "Melee":
                    case "Accuracy":
                    case "Evasion":
                    case "Awakened":
                    case "Defense":
                        OnBasicStatusChanged();
                        break;
                    case "PracticedShooting":
                    case "PracticedMelee":
                    case "PracticedAccuracy":
                    case "PracticedEvasion":
                    case "PracticedAwakened":
                    case "PracticedDefense":
                        OnPracticedStatusChanged();
                        break;
                    case "Ability1":
                    case "Ability2":
                    case "Ability3":
                        OnAbilityChanged();
                        break;
                    default:
                        break;
                }
            }).AddTo(Disposables);

            CalcPracticedTotal();
            CalcEnhancements();
            SetEnhancements();

            isIdle = true;
        }


        private bool isIdle;

        #region entity wrappers

        public Serial? Serial
        {
            get => Entity.Serial;
            set
            {
                Entity.Serial = value;
                Entity.SerialId = value?.Id ?? 0;
                OnPropertyChanged();
            }
        }
        public PilotSkill? Skill
        {
            get => Entity.Skill;
            set
            {
                Entity.Skill = value;
                Entity.SkillId = value?.Id ?? 0;
                OnPropertyChanged();
            }
        }
        public PilotAbility? Ability1
        {
            get => Entity.Ability1;
            set
            {
                Entity.Ability1 = value;
                Entity.Ability1Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public PilotAbility? Ability2
        {
            get => Entity.Ability2;
            set
            {
                Entity.Ability2 = value;
                Entity.Ability2Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public PilotAbility? Ability3
        {
            get => Entity.Ability3;
            set
            {
                Entity.Ability3 = value;
                Entity.Ability3Id = value?.Id;
                OnPropertyChanged();
            }
        }

        public List<Wrapper<byte, PilotAbility?>> Abilities { get; }

        #endregion

        #region entity expansions

        public int PracticedTotal { get => __PracticedTotal; private set => TrySetValue(ref __PracticedTotal, value); }
        private int __PracticedTotal;

        #endregion

        #region enhancements

        public int AbilityShooting { get => __AbilityShooting; private set => TrySetValue(ref __AbilityShooting, value); }
        private int __AbilityShooting;
        public int AbilityMelee { get => __AbilityMelee; private set => TrySetValue(ref __AbilityMelee, value); }
        private int __AbilityMelee;
        public int AbilityAccuracy { get => __AbilityAccuracy; private set => TrySetValue(ref __AbilityAccuracy, value); }
        private int __AbilityAccuracy;
        public int AbilityEvasion { get => __AbilityEvasion; private set => TrySetValue(ref __AbilityEvasion, value); }
        private int __AbilityEvasion;
        public int AbilityAwakened { get => __AbilityAwakened; private set => TrySetValue(ref __AbilityAwakened, value); }
        private int __AbilityAwakened;
        public int AbilityDefense { get => __AbilityDefense; private set => TrySetValue(ref __AbilityDefense, value); }
        private int __AbilityDefense;

        public int ActualShooting { get => __ActualShooting; private set => TrySetValue(ref __ActualShooting, value); }
        private int __ActualShooting;
        public int ActualMelee { get => __ActualMelee; private set => TrySetValue(ref __ActualMelee, value); }
        private int __ActualMelee;
        public int ActualAccuracy { get => __ActualAccuracy; private set => TrySetValue(ref __ActualAccuracy, value); }
        private int __ActualAccuracy;
        public int ActualEvasion { get => __ActualEvasion; private set => TrySetValue(ref __ActualEvasion, value); }
        private int __ActualEvasion;
        public int ActualAwakened { get => __ActualAwakened; private set => TrySetValue(ref __ActualAwakened, value); }
        private int __ActualAwakened;
        public int ActualDefense { get => __ActualDefense; private set => TrySetValue(ref __ActualDefense, value); }
        private int __ActualDefense;

        public List<Enhancement> Enhancements { get => __Enhancements; private set => TrySetValue(ref __Enhancements, value); }
        private List<Enhancement> __Enhancements = null!;

        #endregion


        public void ResetPracticed()
        {
            isIdle = false;
            Entity.PracticedShooting = 0;
            Entity.PracticedMelee = 0;
            Entity.PracticedAccuracy = 0;
            Entity.PracticedEvasion = 0;
            Entity.PracticedAwakened = 0;
            Entity.PracticedDefense = 0;
            isIdle = true;

            OnPracticedStatusChanged();
        }


        private void OnBasicStatusChanged() =>
            SetEnhancements();

        private void OnPracticedStatusChanged()
        {
            if (!isIdle) return;

            CalcPracticedTotal();
            SetEnhancements();
        }

        private void CalcPracticedTotal()
        {
            PracticedTotal = Entity.PracticedShooting + Entity.PracticedMelee + Entity.PracticedAccuracy + Entity.PracticedEvasion + Entity.PracticedAwakened + Entity.PracticedDefense;
        }

        private void OnAbilityChanged()
        {
            CalcEnhancements();
            SetEnhancements();
        }


        private void CalcEnhancements()
        {
            var source = Abilities.Where(w => w.Item2 != null && w.Item2.IsValid()).Select(w => w.Item2!);

            Enhancements?.Clear();
            Enhancements = source.SelectMany(CreateEnhancements).ToList();

            // 同じ Target2Type が選択できるのでグループ化する
            var enhancements = source
                .Where(e => e.Target1Type == Target1Type.Pilot)
                .GroupBy(a => a.Target2Type)
                .ToDictionary(g => g.Key, g => (0, g.Sum(e => e.Value)));

            AbilityShooting = enhancements.TryGetEnhancementValue(Target2Type.Shooting);
            AbilityMelee = enhancements.TryGetEnhancementValue(Target2Type.Melee);
            AbilityAccuracy = enhancements.TryGetEnhancementValue(Target2Type.Accuracy);
            AbilityEvasion = enhancements.TryGetEnhancementValue(Target2Type.Evasion);
            AbilityAwakened = enhancements.TryGetEnhancementValue(Target2Type.Awakened);
            AbilityDefense = enhancements.TryGetEnhancementValue(Target2Type.Defense);
        }

        private Enhancement[] CreateEnhancements(PilotAbility ability)
        {
            if (ability.Target2Type == Target2Type.BeamAndPhysicalAttack)
            {
                return new Enhancement[]
                    { 
                        new Enhancement(ability, Target2Type.BeamAttack),
                        new Enhancement(ability, Target2Type.PhysicalAttack),
                    };
            }
            else if (ability.Target2Type == Target2Type.BeamAndPhysicalDefence)
            {
                return new Enhancement[]
                    {
                        new Enhancement(ability, Target2Type.BeamDefence),
                        new Enhancement(ability, Target2Type.PhysicalDefence),
                    };
            }
            else
            {
                return new Enhancement[] { new Enhancement(ability), };
            }
        }

        private void SetEnhancements()
        {
            ActualShooting = Entity.Shooting + Entity.PracticedShooting + AbilityShooting;
            ActualMelee = Entity.Melee + Entity.PracticedMelee + AbilityMelee;
            ActualAccuracy = Entity.Accuracy + Entity.PracticedAccuracy + AbilityAccuracy;
            ActualEvasion = Entity.Evasion + Entity.PracticedEvasion + AbilityEvasion;
            ActualAwakened = Entity.Awakened + Entity.PracticedAwakened + AbilityAwakened;
            ActualDefense = Entity.Defense + Entity.PracticedDefense + AbilityDefense;
        }

    }

}
