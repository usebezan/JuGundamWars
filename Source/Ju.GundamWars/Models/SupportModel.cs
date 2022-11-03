using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Linq;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Models
{

    public class SupportModel : ModelBase<Support, SupportRepository>
    {

        public static SupportModel Create() =>
            Create(new());

        public static SupportModel Create(Support entity) =>
            new(entity, GetRequiredService<SupportRepository>());


        public SupportModel(Support entity, SupportRepository repository)
            : base(entity, repository)
        {
            isIdle = false;

            LimitedSerials = new()
            {
                new(() => LimitedSerial1, v => LimitedSerial1 = v),
                new(() => LimitedSerial2, v => LimitedSerial2 = v),
                new(() => LimitedSerial3, v => LimitedSerial3 = v),
                new(() => LimitedSerial4, v => LimitedSerial4 = v),
                new(() => LimitedSerial5, v => LimitedSerial5 = v),
                new(() => LimitedSerial6, v => LimitedSerial6 = v),
            };
            SlotBadges = new()
            {
                new(() => Slot1, v => Slot1 = v, () => Badge1, v => Badge1 = v),
                new(() => Slot2, v => Slot2 = v, () => Badge2, v => Badge2 = v),
                new(() => Slot3, v => Slot3 = v, () => Badge3, v => Badge3 = v),
                new(() => Slot4, v => Slot4 = v, () => Badge4, v => Badge4 = v),
                new(() => Slot5, v => Slot5 = v, () => Badge5, v => Badge5 = v),
                new(() => Slot6, v => Slot6 = v, () => Badge6, v => Badge6 = v),
                new(() => Slot7, v => Slot7 = v, () => Badge7, v => Badge7 = v),
                new(() => Slot8, v => Slot8 = v, () => Badge8, v => Badge8 = v),
                new(() => Slot9, v => Slot9 = v, () => Badge9, v => Badge9 = v),
                new(() => Slot10, v => Slot10 = v, () => Badge10, v => Badge10 = v),
                new(() => Slot11, v => Slot11 = v, () => Badge11, v => Badge11 = v),
                new(() => Slot12, v => Slot12 = v, () => Badge12, v => Badge12 = v),
            };

            Enhancements = new();
            EnhancementsSummary = new();

            _ = Entity.PropertyChanged.Subscribe(n =>
            {
                switch (n)
                {
                    case "LimitedSerial1":
                    case "LimitedSerial2":
                    case "LimitedSerial3":
                    case "LimitedSerial4":
                    case "LimitedSerial5":
                    case "LimitedSerial6":
                        OnLimitedSerialChanged();
                        break;
                    case "Slot1":
                    case "Slot2":
                    case "Slot3":
                    case "Slot4":
                    case "Slot5":
                    case "Slot6":
                    case "Slot7":
                    case "Slot8":
                    case "Slot9":
                    case "Slot10":
                    case "Slot11":
                    case "Slot12":
                        OnSlotChanged();
                        break;
                    case "Badge1":
                    case "Badge2":
                    case "Badge3":
                    case "Badge4":
                    case "Badge5":
                    case "Badge6":
                    case "Badge7":
                    case "Badge8":
                    case "Badge9":
                    case "Badge10":
                    case "Badge11":
                    case "Badge12":
                        OnBadgeChanged();
                        break;
                    default:
                        break;
                }
            }).AddTo(Disposables);

            LimitedSerialsText = JoinLimitedSerials();
            SlotsText = JoinSlots();
            SlotsCount = GetSlotsCount();
            BadgesText = JoinBadges();
            BadgesCount = GetBadgesCount();
            CalcEnhancements();

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
        public Serial? LimitedSerial1
        {
            get => Entity.LimitedSerial1;
            set
            {
                Entity.LimitedSerial1 = value;
                Entity.LimitedSerial1Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public Serial? LimitedSerial2
        {
            get => Entity.LimitedSerial2;
            set
            {
                Entity.LimitedSerial2 = value;
                Entity.LimitedSerial2Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public Serial? LimitedSerial3
        {
            get => Entity.LimitedSerial3;
            set
            {
                Entity.LimitedSerial3 = value;
                Entity.LimitedSerial3Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public Serial? LimitedSerial4
        {
            get => Entity.LimitedSerial4;
            set
            {
                Entity.LimitedSerial4 = value;
                Entity.LimitedSerial4Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public Serial? LimitedSerial5
        {
            get => Entity.LimitedSerial5;
            set
            {
                Entity.LimitedSerial5 = value;
                Entity.LimitedSerial5Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public Serial? LimitedSerial6
        {
            get => Entity.LimitedSerial6;
            set
            {
                Entity.LimitedSerial6 = value;
                Entity.LimitedSerial6Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot1
        {
            get => Entity.Slot1;
            set
            {
                Entity.Slot1 = value;
                Entity.Slot1Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge1
        {
            get => Entity.Badge1;
            set
            {
                Entity.Badge1 = value;
                Entity.Badge1Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot2
        {
            get => Entity.Slot2;
            set
            {
                Entity.Slot2 = value;
                Entity.Slot2Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge2
        {
            get => Entity.Badge2;
            set
            {
                Entity.Badge2 = value;
                Entity.Badge2Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot3
        {
            get => Entity.Slot3;
            set
            {
                Entity.Slot3 = value;
                Entity.Slot3Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge3
        {
            get => Entity.Badge3;
            set
            {
                Entity.Badge3 = value;
                Entity.Badge3Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot4
        {
            get => Entity.Slot4;
            set
            {
                Entity.Slot4 = value;
                Entity.Slot4Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge4
        {
            get => Entity.Badge4;
            set
            {
                Entity.Badge4 = value;
                Entity.Badge4Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot5
        {
            get => Entity.Slot5;
            set
            {
                Entity.Slot5 = value;
                Entity.Slot5Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge5
        {
            get => Entity.Badge5;
            set
            {
                Entity.Badge5 = value;
                Entity.Badge5Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot6
        {
            get => Entity.Slot6;
            set
            {
                Entity.Slot6 = value;
                Entity.Slot6Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge6
        {
            get => Entity.Badge6;
            set
            {
                Entity.Badge6 = value;
                Entity.Badge6Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot7
        {
            get => Entity.Slot7;
            set
            {
                Entity.Slot7 = value;
                Entity.Slot7Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge7
        {
            get => Entity.Badge7;
            set
            {
                Entity.Badge7 = value;
                Entity.Badge7Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot8
        {
            get => Entity.Slot8;
            set
            {
                Entity.Slot8 = value;
                Entity.Slot8Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge8
        {
            get => Entity.Badge8;
            set
            {
                Entity.Badge8 = value;
                Entity.Badge8Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot9
        {
            get => Entity.Slot9;
            set
            {
                Entity.Slot9 = value;
                Entity.Slot9Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge9
        {
            get => Entity.Badge9;
            set
            {
                Entity.Badge9 = value;
                Entity.Badge9Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot10
        {
            get => Entity.Slot10;
            set
            {
                Entity.Slot10 = value;
                Entity.Slot10Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge10
        {
            get => Entity.Badge10;
            set
            {
                Entity.Badge10 = value;
                Entity.Badge10Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot11
        {
            get => Entity.Slot11;
            set
            {
                Entity.Slot11 = value;
                Entity.Slot11Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge11
        {
            get => Entity.Badge11;
            set
            {
                Entity.Badge11 = value;
                Entity.Badge11Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportSlot? Slot12
        {
            get => Entity.Slot12;
            set
            {
                Entity.Slot12 = value;
                Entity.Slot12Id = value?.Id;
                OnPropertyChanged();
            }
        }
        public SupportBadge? Badge12
        {
            get => Entity.Badge12;
            set
            {
                Entity.Badge12 = value;
                Entity.Badge12Id = value?.Id;
                OnPropertyChanged();
            }
        }

        public List<Wrapper<Serial?>> LimitedSerials { get; }
        public List<Wrapper<SupportSlot?, SupportBadge?>> SlotBadges { get; }

        #endregion

        #region entity expansions

        public string LimitedSerialsText { get => __LimitedSerialsText; private set => TrySetValue(ref __LimitedSerialsText, value); }
        private string __LimitedSerialsText = "";
        public string SlotsText { get => __SlotsText; private set => TrySetValue(ref __SlotsText, value); }
        private string __SlotsText = "";
        public int SlotsCount { get => __SlotsCount; private set => TrySetValue(ref __SlotsCount, value); }
        private int __SlotsCount;
        public string BadgesText { get => __BadgesText; private set => TrySetValue(ref __BadgesText, value); }
        private string __BadgesText = "";
        public int BadgesCount { get => __BadgesCount; private set => TrySetValue(ref __BadgesCount, value); }
        private int __BadgesCount;

        #endregion

        #region enhancements

        public int Hp { get => __Hp; private set => TrySetValue(ref __Hp, value); }
        private int __Hp;
        public int BeamAttack { get => __BeamAttack; private set => TrySetValue(ref __BeamAttack, value); }
        private int __BeamAttack;
        public int PhysicalAttack { get => __PhysicalAttack; private set => TrySetValue(ref __PhysicalAttack, value); }
        private int __PhysicalAttack;
        public int BeamDefence { get => __BeamDefence; private set => TrySetValue(ref __BeamDefence, value); }
        private int __BeamDefence;
        public int PhysicalDefence { get => __PhysicalDefence; private set => TrySetValue(ref __PhysicalDefence, value); }
        private int __PhysicalDefence;
        public int CriticalRate { get => __CriticalRate; private set => TrySetValue(ref __CriticalRate, value); }
        private int __CriticalRate;
        public int CriticalDamage { get => __CriticalDamage; private set => TrySetValue(ref __CriticalDamage, value); }
        private int __CriticalDamage;
        public int Accuracy { get => __Accuracy; private set => TrySetValue(ref __Accuracy, value); }
        private int __Accuracy;
        public int Evasion { get => __Evasion; private set => TrySetValue(ref __Evasion, value); }
        private int __Evasion;
        public int Mobility { get => __Mobility; private set => TrySetValue(ref __Mobility, value); }
        private int __Mobility;
        public int EnRecovery { get => __EnRecovery; private set => TrySetValue(ref __EnRecovery, value); }
        private int __EnRecovery;
        public int SuperPower { get => __SuperPower; private set => TrySetValue(ref __SuperPower, value); }
        private int __SuperPower;
        public int AcePower { get => __AcePower; private set => TrySetValue(ref __AcePower, value); }
        private int __AcePower;
        public int RecoveryPower { get => __RecoveryPower; private set => TrySetValue(ref __RecoveryPower, value); }
        private int __RecoveryPower;

        public List<Enhancement> Enhancements { get => __Enhancements; private set => TrySetValue(ref __Enhancements, value); }
        private List<Enhancement> __Enhancements = null!;
        public ObservableCollection<KeyValuePair<string, string>> EnhancementsSummary { get; }

        #endregion


        public void DetachAllBadges()
        {
            isIdle = false;
            SlotBadges.ForEach(w => w.Item2 = null);
            isIdle = true;

            OnBadgeChanged();
        }


        private void OnLimitedSerialChanged() =>
            LimitedSerialsText = JoinLimitedSerials();

        private string JoinLimitedSerials() =>
            string.Join(", ", LimitedSerials.Where(w => w.Item1 != null).OrderBy(w => w.Item1!.Order).Select(w => w.Item1!.Name));


        private void OnSlotChanged()
        {
            isIdle = false;
            SlotBadges.ForEach(w =>
            {
                if (w.Item1 == null || !w.Item1.IsAttachable)
                {
                    w.Item2 = null;
                }
            });
            isIdle = true;

            SlotsText = JoinSlots();
            SlotsCount = GetSlotsCount();
            BadgesText = JoinBadges();
            BadgesCount = GetBadgesCount();
            CalcEnhancements();
        }

        private string JoinSlots() =>
            string.Join(", ", SlotBadges
                .Where(w => w.Item1 != null && (w.Item1.SlotType == SlotType.Unlock || w.Item1.SlotType == SlotType.Bonus))
                .Select(w => w.Item1!.Name));

        private int GetSlotsCount() =>
            SlotBadges
                .Where(w => w.Item1 != null && w.Item1.IsAttachable)
                .Count();


        private void OnBadgeChanged()
        {
            if (!isIdle) return;

            BadgesText = JoinBadges();
            BadgesCount = GetBadgesCount();
            CalcEnhancements();
        }

        private string JoinBadges() =>
            string.Join(", ", SlotBadges
                .Where(w => w.Item1 != null && w.Item2 != null)
                .Select(GetBonusPrefix));

        private string GetBonusPrefix(Wrapper<SupportSlot?, SupportBadge?> slotBadge) =>
            slotBadge.Item1 != null && slotBadge.Item2 != null && slotBadge.Item1.Target2 == slotBadge.Item2.Target2
                ? $"@{slotBadge.Item2.Name}"
                : slotBadge.Item2?.Name ?? "";

        private int GetBadgesCount() =>
            SlotBadges
                .Where(w => w.Item1 != null && w.Item1.IsAttachable && w.Item2 != null)
                .Count();


        private void CalcEnhancements()
        {
            var source = SlotBadges.Select(CalcEnhancement).Where(a => a.Enhancement != null && a.Enhancement.IsValid());

            Enhancements?.Clear();
            Enhancements = source.Select(a => new Enhancement(a.Enhancement!, a.Value)).ToList();

            var enhancementsSummary = source
                .GroupBy(a => new { a.Enhancement!.Target2Type, a.Enhancement!.CalcType})
                .OrderBy(g => g.Key.Target2Type)
                .ToDictionary(g => g.Key.Target2Type, g => (g.Key.CalcType, g.Sum(e => e.Value)));

            Hp = enhancementsSummary.TryGetEnhancementValue(Target2Type.Hp);
            BeamAttack = enhancementsSummary.TryGetEnhancementValue(Target2Type.BeamAttack);
            PhysicalAttack = enhancementsSummary.TryGetEnhancementValue(Target2Type.PhysicalAttack);
            BeamDefence = enhancementsSummary.TryGetEnhancementValue(Target2Type.BeamDefence);
            PhysicalDefence = enhancementsSummary.TryGetEnhancementValue(Target2Type.PhysicalDefence);
            CriticalRate = enhancementsSummary.TryGetEnhancementValue(Target2Type.CriticalRate);
            CriticalDamage = enhancementsSummary.TryGetEnhancementValue(Target2Type.CriticalDamage);
            Accuracy = enhancementsSummary.TryGetEnhancementValue(Target2Type.Accuracy);
            Evasion = enhancementsSummary.TryGetEnhancementValue(Target2Type.Evasion);
            Mobility = enhancementsSummary.TryGetEnhancementValue(Target2Type.Mobility);
            EnRecovery = enhancementsSummary.TryGetEnhancementValue(Target2Type.EnRecovery);
            SuperPower = enhancementsSummary.TryGetEnhancementValue(Target2Type.SuperPower);
            AcePower = enhancementsSummary.TryGetEnhancementValue(Target2Type.AcePower);
            RecoveryPower = enhancementsSummary.TryGetEnhancementValue(Target2Type.RecoveryPower);

            EnhancementsSummary.Clear();
            foreach (var enhancement in enhancementsSummary)
            {
                EnhancementsSummary.Add(new(enhancement.Key.ToText(), GetValueText(enhancement.Value)));
            }
        }

        private (IEnhancement? Enhancement, int Value) CalcEnhancement(Wrapper<SupportSlot?, SupportBadge?> slotBadge)
        {
            if (slotBadge.Item1 == null) return (null, 0);

            var slotTarget1Type = slotBadge.Item1.Target1Type;

            if (slotTarget1Type == Target1Type.Unit)
            {
                return (slotBadge.Item1, slotBadge.Item1.Value);
            }
            else if (slotTarget1Type == Target1Type.Badge)
            {
                if (slotBadge.Item2 == null) return (null, 0);
                var value = slotBadge.Item2.Value;
                if (slotBadge.Item1.Target2Type == slotBadge.Item2.Target2Type)
                {
                    value += slotBadge.Item1.Calc(value);
                }
                return (slotBadge.Item2, value);

            }
            return (null, 0);
        }

        private string GetValueText((CalcType CalcType, int Value) enhancement) =>
            enhancement.CalcType switch
            {
                CalcType.Addition => $"+{enhancement.Value}",
                CalcType.Multiplication => $"{enhancement.Value}%UP",
                _ => "",
            };

    }

}
