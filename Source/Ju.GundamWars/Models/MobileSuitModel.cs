using Ju.GundamWars.Models.Entities;
using Ju.GundamWars.Models.Repositories;
using Reactive.Bindings.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using static Ju.GundamWars.App;


namespace Ju.GundamWars.Models
{

    public class MobileSuitModel : ModelBase<MobileSuit, MobileSuitRepository>
    {

        public static MobileSuitModel Create() =>
            Create(new());

        public static MobileSuitModel Create(MobileSuit entity) =>
            new(entity, GetRequiredService<MobileSuitRepository>(), GetRequiredService<PilotModelRepository>(), GetRequiredService<SupportModelRepository>());


        public MobileSuitModel(MobileSuit entity, MobileSuitRepository repository, PilotModelRepository pilotModelRepository, SupportModelRepository supportModelRepository)
            : base(entity, repository)
        {
            this.pilotModelRepository = pilotModelRepository ?? throw new ArgumentNullException(nameof(pilotModelRepository));
            this.supportModelRepository = supportModelRepository ?? throw new ArgumentNullException(nameof(supportModelRepository));

            __Pilot = this.pilotModelRepository.GetModel(Entity.Pilot);
            __Support1 = this.supportModelRepository.GetModel(Entity.Support1);
            __Support2 = this.supportModelRepository.GetModel(Entity.Support2);
            __Support3 = this.supportModelRepository.GetModel(Entity.Support3);
            __Support4 = this.supportModelRepository.GetModel(Entity.Support4);

            SubSerials = new()
            {
                new(() => SubSerial1, v => SubSerial1 = v),
                new(() => SubSerial2, v => SubSerial2 = v),
                new(() => SubSerial3, v => SubSerial3 = v),
                new(() => SubSerial4, v => SubSerial4 = v),
            };
            Supports = new()
            {
                new(() => Support1, v => Support1 = v),
                new(() => Support2, v => Support2 = v),
                new(() => Support3, v => Support3 = v),
                new(() => Support4, v => Support4 = v),
            };
            SAbilities = new()
            {
                new(() => SAbility1, v => SAbility1 = v),
                new(() => SAbility2, v => SAbility2 = v),
                new(() => SAbility3, v => SAbility3 = v),
                new(() => SAbility4, v => SAbility4 = v),
            };

            _ = Entity.PropertyChanged.Subscribe(n =>
            {
                switch (n)
                {
                    case "SubSerial1":
                    case "SubSerial2":
                    case "SubSerial3":
                    case "SubSerial4":
                        OnSubSerialChanged();
                        break;
                    case "Pilot":
                        OnPilotChanged();
                        break;
                    case "Support1":
                    case "Support2":
                    case "Support3":
                    case "Support4":
                        OnSupportChanged();
                        break;
                    case "SAbility1":
                    case "SAbility2":
                    case "SAbility3":
                    case "SAbility4":
                        OnSAbilityChanged();
                        break;
                    default:
                        break;
                }
            }).AddTo(Disposables);
        }


        private readonly PilotModelRepository pilotModelRepository;
        private readonly SupportModelRepository supportModelRepository;

        private bool isIdle;

        #region entity wrappers

        public Serial? Serial
        {
            get => Entity.Serial;
            set
            {
                Entity.Serial = value;
                Entity.SerialId = value?.Id ?? 0;
            }
        }
        public Serial? SubSerial1
        {
            get => Entity.SubSerial1;
            set
            {
                Entity.SubSerial1 = value;
                Entity.SubSerial1Id = value?.Id;
            }
        }
        public Serial? SubSerial2
        {
            get => Entity.SubSerial2;
            set
            {
                Entity.SubSerial2 = value;
                Entity.SubSerial2Id = value?.Id;
            }
        }
        public Serial? SubSerial3
        {
            get => Entity.SubSerial3;
            set
            {
                Entity.SubSerial3 = value;
                Entity.SubSerial3Id = value?.Id;
            }
        }
        public Serial? SubSerial4
        {
            get => Entity.SubSerial4;
            set
            {
                Entity.SubSerial4 = value;
                Entity.SubSerial4Id = value?.Id;
            }
        }
        public PilotModel? Pilot
        {
            get => __Pilot;
            set
            {
                __Pilot = value;
                Entity.Pilot = value?.Entity;
                Entity.PilotId = value?.Entity?.Id;

                value?.PropertyChanged.Where(n => n == "Enhancements").DisposePreviousValue().Subscribe(_ => OnPilotEnhancementsChanged()).AddTo(Disposables);
            }
        }
        private PilotModel? __Pilot;
        public SupportModel? Support1
        {
            get => __Support1;
            set
            {
                __Support1 = value;
                Entity.Support1 = value?.Entity;
                Entity.Support1Id = value?.Entity?.Id;
            }
        }
        private SupportModel? __Support1;
        public SupportModel? Support2
        {
            get => __Support2;
            set
            {
                __Support2 = value;
                Entity.Support2 = value?.Entity;
                Entity.Support2Id = value?.Entity?.Id;
            }
        }
        private SupportModel? __Support2;
        public SupportModel? Support3
        {
            get => __Support3;
            set
            {
                __Support3 = value;
                Entity.Support3 = value?.Entity;
                Entity.Support3Id = value?.Entity?.Id;
            }
        }
        private SupportModel? __Support3;
        public SupportModel? Support4
        {
            get => __Support4;
            set
            {
                __Support4 = value;
                Entity.Support4 = value?.Entity;
                Entity.Support4Id = value?.Entity?.Id;
            }
        }
        private SupportModel? __Support4;
        public UnitSAbility? SAbility1
        {
            get => Entity.SAbility1;
            set
            {
                Entity.SAbility1 = value;
                Entity.SAbility1Id = value?.Id;
            }
        }
        public UnitSAbility? SAbility2
        {
            get => Entity.SAbility2;
            set
            {
                Entity.SAbility2 = value;
                Entity.SAbility2Id = value?.Id;
            }
        }
        public UnitSAbility? SAbility3
        {
            get => Entity.SAbility3;
            set
            {
                Entity.SAbility3 = value;
                Entity.SAbility3Id = value?.Id;
            }
        }
        public UnitSAbility? SAbility4
        {
            get => Entity.SAbility4;
            set
            {
                Entity.SAbility4 = value;
                Entity.SAbility4Id = value?.Id;
            }
        }

        public List<Wrapper<Serial?>> SubSerials { get; }
        public List<Wrapper<SupportModel?>> Supports { get; }
        public List<Wrapper<UnitSAbility?>> SAbilities { get; }

        #endregion

        #region entity expansions

        public string SubSerialsText { get => __SubSerialsText; private set => TrySetValue(ref __SubSerialsText, value); }
        private string __SubSerialsText = "";
        public string SAbilitysText { get => __SAbilitysText; private set => TrySetValue(ref __SAbilitysText, value); }
        private string __SAbilitysText = "";

        #endregion

        #region enhancements

        public int PilotHp { get => __PilotHp; private set => TrySetValue(ref __PilotHp, value); }
        private int __PilotHp;
        public int PilotBeamAttack { get => __PilotBeamAttack; private set => TrySetValue(ref __PilotBeamAttack, value); }
        private int __PilotBeamAttack;
        public int PilotPhysicalAttack { get => __PilotPhysicalAttack; private set => TrySetValue(ref __PilotPhysicalAttack, value); }
        private int __PilotPhysicalAttack;
        public int PilotBeamDefence { get => __PilotBeamDefence; private set => TrySetValue(ref __PilotBeamDefence, value); }
        private int __PilotBeamDefence;
        public int PilotPhysicalDefence { get => __PilotPhysicalDefence; private set => TrySetValue(ref __PilotPhysicalDefence, value); }
        private int __PilotPhysicalDefence;
        public int PilotCriticalRate { get => __PilotCriticalRate; private set => TrySetValue(ref __PilotCriticalRate, value); }
        private int __PilotCriticalRate;
        public int PilotCriticalDamage { get => __PilotCriticalDamage; private set => TrySetValue(ref __PilotCriticalDamage, value); }
        private int __PilotCriticalDamage;
        public int PilotAccuracy { get => __PilotAccuracy; private set => TrySetValue(ref __PilotAccuracy, value); }
        private int __PilotAccuracy;
        public int PilotEvasion { get => __PilotEvasion; private set => TrySetValue(ref __PilotEvasion, value); }
        private int __PilotEvasion;
        public int PilotMobility { get => __PilotMobility; private set => TrySetValue(ref __PilotMobility, value); }
        private int __PilotMobility;
        public int PilotEnRecovery { get => __PilotEnRecovery; private set => TrySetValue(ref __PilotEnRecovery, value); }
        private int __PilotEnRecovery;
        public int PilotSuperMove { get => __PilotSuperMove; private set => TrySetValue(ref __PilotSuperMove, value); }
        private int __PilotSuperMove;
        public int PilotAceMove { get => __PilotAceMove; private set => TrySetValue(ref __PilotAceMove, value); }
        private int __PilotAceMove;
        public int PilotRecoveryPower { get => __PilotRecoveryPower; private set => TrySetValue(ref __PilotRecoveryPower, value); }
        private int __PilotRecoveryPower;

        public int SupportHp { get => __SupportHp; private set => TrySetValue(ref __SupportHp, value); }
        private int __SupportHp;
        public int SupportBeamAttack { get => __SupportBeamAttack; private set => TrySetValue(ref __SupportBeamAttack, value); }
        private int __SupportBeamAttack;
        public int SupportPhysicalAttack { get => __SupportPhysicalAttack; private set => TrySetValue(ref __SupportPhysicalAttack, value); }
        private int __SupportPhysicalAttack;
        public int SupportBeamDefence { get => __SupportBeamDefence; private set => TrySetValue(ref __SupportBeamDefence, value); }
        private int __SupportBeamDefence;
        public int SupportPhysicalDefence { get => __SupportPhysicalDefence; private set => TrySetValue(ref __SupportPhysicalDefence, value); }
        private int __SupportPhysicalDefence;
        public int SupportCriticalRate { get => __SupportCriticalRate; private set => TrySetValue(ref __SupportCriticalRate, value); }
        private int __SupportCriticalRate;
        public int SupportCriticalDamage { get => __SupportCriticalDamage; private set => TrySetValue(ref __SupportCriticalDamage, value); }
        private int __SupportCriticalDamage;
        public int SupportAccuracy { get => __SupportAccuracy; private set => TrySetValue(ref __SupportAccuracy, value); }
        private int __SupportAccuracy;
        public int SupportEvasion { get => __SupportEvasion; private set => TrySetValue(ref __SupportEvasion, value); }
        private int __SupportEvasion;
        public int SupportMobility { get => __SupportMobility; private set => TrySetValue(ref __SupportMobility, value); }
        private int __SupportMobility;
        public int SupportEnRecovery { get => __SupportEnRecovery; private set => TrySetValue(ref __SupportEnRecovery, value); }
        private int __SupportEnRecovery;
        public int SupportSuperMove { get => __SupportSuperMove; private set => TrySetValue(ref __SupportSuperMove, value); }
        private int __SupportSuperMove;
        public int SupportAceMove { get => __SupportAceMove; private set => TrySetValue(ref __SupportAceMove, value); }
        private int __SupportAceMove;
        public int SupportRecoveryPower { get => __SupportRecoveryPower; private set => TrySetValue(ref __SupportRecoveryPower, value); }
        private int __SupportRecoveryPower;

        public int HpWithoutPilot => Entity.Hp + Entity.RemodelingHp + Entity.CustomHp + SupportHp;
        public int BeamAttackWithoutPilot => Entity.BeamAttack + Entity.RemodelingBeamAttack + Entity.CustomBeamAttack + SupportBeamAttack;
        public int PhysicalAttackWithoutPilot => Entity.PhysicalAttack + Entity.RemodelingPhysicalAttack + Entity.CustomPhysicalAttack + SupportPhysicalAttack;
        public int BeamDefenceWithoutPilot => Entity.BeamDefence + Entity.RemodelingBeamDefence + Entity.CustomBeamDefence + SupportBeamDefence;
        public int PhysicalDefenceWithoutPilot => Entity.PhysicalDefence + Entity.RemodelingPhysicalDefence + Entity.CustomPhysicalDefence + SupportPhysicalDefence;
        public int CriticalRateWithoutPilot => Entity.CriticalRate + Entity.RemodelingCriticalRate + Entity.CustomCriticalRate + SupportCriticalRate;
        public int CriticalDamageWithoutPilot => Entity.CriticalDamage + Entity.RemodelingCriticalDamage + Entity.CustomCriticalDamage + SupportCriticalDamage;
        public int AccuracyWithoutPilot => Entity.Accuracy + Entity.RemodelingAccuracy + Entity.CustomAccuracy + SupportAccuracy;
        public int EvasionWithoutPilot => Entity.Evasion + Entity.RemodelingEvasion + Entity.CustomEvasion + SupportEvasion;
        public int MobilityWithoutPilot => Entity.Mobility + Entity.RemodelingMobility + Entity.CustomMobility + SupportMobility;
        public int SuperEnRecoveryWithoutPilot => Entity.SuperEnRecovery + Entity.RemodelingEnRecovery + Entity.CustomEnRecovery + SupportEnRecovery;
        public int AceEnRecoveryWithoutPilot => Entity.AceEnRecovery + Entity.RemodelingEnRecovery + Entity.CustomEnRecovery + SupportEnRecovery;

        #endregion


        private void OnSubSerialChanged() =>
            SubSerialsText = JoinSubSerials();

        private string JoinSubSerials() =>
            string.Join(", ", SubSerials.Where(w => w.Item1 != null).OrderBy(w => w.Item1!.Order).Select(w => w.Item1!.Name));


        //private Enhancement GetEnhancement(List<Enhancement> enhancements, Target2Type target1Type2)
        //{

        //}

        private void OnPilotChanged()
        {
            CalcPilotEnhancements();
        }

        private void OnPilotEnhancementsChanged()
        {
            CalcPilotEnhancements();
        }

        private void CalcPilotEnhancements()
        {
            var bases = new Dictionary<Target2Type, int>()
                {
                    { Target2Type.Hp, HpWithoutPilot },
                    { Target2Type.BeamAttack, BeamAttackWithoutPilot },
                    { Target2Type.PhysicalAttack, PhysicalAttackWithoutPilot },
                    { Target2Type.BeamDefence, BeamDefenceWithoutPilot },
                    { Target2Type.PhysicalDefence, PhysicalDefenceWithoutPilot },
                    { Target2Type.CriticalRate, CriticalRateWithoutPilot },
                    { Target2Type.CriticalDamage, CriticalDamageWithoutPilot },
                    { Target2Type.Accuracy, AccuracyWithoutPilot },
                    { Target2Type.Evasion, EvasionWithoutPilot },
                    { Target2Type.Mobility, MobilityWithoutPilot },
                    { Target2Type.EnRecovery, SuperEnRecoveryWithoutPilot },
                };

            var enhancements = new Dictionary<Target2Type, int>()
                {
                    { Target2Type.Hp, 0 },
                    { Target2Type.BeamAttack, 0 },
                    { Target2Type.PhysicalAttack, 0 },
                    { Target2Type.BeamDefence, 0 },
                    { Target2Type.PhysicalDefence, 0 },
                    { Target2Type.CriticalRate, 0 },
                    { Target2Type.CriticalDamage, 0 },
                    { Target2Type.Accuracy, 0 },
                    { Target2Type.Evasion, 0 },
                    { Target2Type.Mobility, 0 },
                    { Target2Type.EnRecovery, 0 },
                };

            var aceEnRecovery = 0;

            Pilot?.Enhancements
                .Where(e => e.Target1Type == Target1Type.Unit && enhancements.ContainsKey(e.Target2Type))
                .ToList()
                .ForEach(e =>
                {
                    var key = e.Target2Type;
                    enhancements[key] += e.Calc(bases[key] + enhancements[key]);
                    if (key == Target2Type.EnRecovery)
                    {
                        aceEnRecovery += e.Calc(AceEnRecoveryWithoutPilot + aceEnRecovery);
                    }
                });

            PilotHp = enhancements.TryGetEnhancementValue(Target2Type.Hp);
            PilotBeamAttack = enhancements.TryGetEnhancementValue(Target2Type.BeamAttack);
            PilotPhysicalAttack = enhancements.TryGetEnhancementValue(Target2Type.PhysicalAttack);
            PilotBeamDefence = enhancements.TryGetEnhancementValue(Target2Type.BeamDefence);
            PilotPhysicalDefence = enhancements.TryGetEnhancementValue(Target2Type.PhysicalDefence);
            PilotCriticalRate = enhancements.TryGetEnhancementValue(Target2Type.CriticalRate);
            PilotCriticalDamage = enhancements.TryGetEnhancementValue(Target2Type.CriticalDamage);
            PilotAccuracy = enhancements.TryGetEnhancementValue(Target2Type.Accuracy);
            PilotEvasion = enhancements.TryGetEnhancementValue(Target2Type.Evasion);
            PilotMobility = enhancements.TryGetEnhancementValue(Target2Type.Mobility);
            PilotEnRecovery = enhancements.TryGetEnhancementValue(Target2Type.EnRecovery);
            PilotSuperMove = enhancements.TryGetEnhancementValue(Target2Type.SuperPower);
            PilotAceMove = enhancements.TryGetEnhancementValue(Target2Type.AcePower);
            PilotRecoveryPower = enhancements.TryGetEnhancementValue(Target2Type.RecoveryPower);
        }

        //private int CalcEnhancement(IEnhancement enhancement, int value)
        //{
        //    if (enhancement.CalcType == CalcType.Addition)
        //    {
        //        value += enhancement.Value;
        //    }
        //    else if (enhancement.CalcType == CalcType.Multiplication)
        //    {
        //        value += value * enhancement.Value / enhancement.Fraction;
        //    }
        //    return value;
        //}


        private void OnSupportChanged()
        {

        }

        private void OnSupportEnhancementsChanged()
        {

        }


        private void SetEnhancements()
        {

        }


        private void OnSAbilityChanged() =>
            SAbilitysText = JoinSAbilitys();

        private string JoinSAbilitys() =>
            string.Join(", ", SAbilities.Where(w => w.Item1 != null).OrderBy(w => w.Item1!.Order).Select(w => w.Item1!.Name));

    }

}
