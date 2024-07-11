using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars;
using Ju.GundamWars.BizTxn._.CoMobiles.Domain.Model;
using Ju.GundamWars.BizTxn._.Cuspas;
using Ju.GundamWars.BizTxn._.Mobiles.Domain.Entities;
using Ju.GundamWars.BizTxn.Pilots.Domain.Model;
using Ju.GundamWars.BizTxn.Supports.Domain.Model;
using Ju.GundamWars.BizMaster.MobileStatuses;
using Ju.GundamWars.Core;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.AceImpls.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Categories.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.CuspaKinds;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Grades.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.MobileKinds;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.MobileKinds.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Positions.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Roles;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Roles.Model;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Serials.Dto;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Terrains.Model;
using Ju.GundamWars.Core.Ju.GundamWars.System;
using Ju.GundamWars.Domain.CoMobiles;
using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Ju.GundamWars.BizTxn._.Mobiles.Domain;

public partial class MobileSubject : SubjectBase
{

    public MobileSubject()
    {
        BasicStatus = new MobileStatusSubject().AddTo(Disposables);
        RemodeledStatus = new MobileRemodeledStatusSubject().AddTo(Disposables);
        SubSerials = [];
        PilotBoost = new MobileStatusSubject().AddTo(Disposables);
        CuspaBoost = new CuspaStatusSubject().AddTo(Disposables);
        SupportBoost = new SupportStatus().AddTo(Disposables);
        SupportBoostOwn = new SupportStatus().AddTo(Disposables);
        CoMobileBoost = new CoMobileStatusSubject().AddTo(Disposables);
        BoostStatus = new MobileStatusSubject().AddTo(Disposables);
        ActualStatus = new MobileStatusSubject().AddTo(Disposables);

        BasicStatus.PropertyChanged.Subscribe(WhenBasicStatusChanged).AddTo(Disposables);
        RemodeledStatus.PropertyChanged.Subscribe(WhenRemodeledStatusChanged).AddTo(Disposables);
        SubSerials.CollectionChanged.Subscribe(WhenSubSerialsChanged).AddTo(Disposables);

        IsIdle = true;
    }


    #region Entity fields

    [ObservableProperty, Required]
    private string _Name = null!;
    [ObservableProperty, Required]
    private byte _Blueprint;
    [ObservableProperty, Required]
    private byte _Proof;
    [ObservableProperty, Required]
    private byte _Level;
    [ObservableProperty, Required]
    private byte _Version;
    [ObservableProperty, Required]
    private byte _SuperEnGrade;
    [ObservableProperty, Required]
    private byte _AceEnGrade;
    [ObservableProperty]
    private int _EnTank;
    [ObservableProperty]
    private string? _SSkillText1;
    [ObservableProperty]
    private string? _SSkillText2;
    [ObservableProperty, Required]
    private byte _SupportProof;
    [ObservableProperty, Required]
    private byte _SupportUnlock;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(HasMemo))]
    private string? _Memo;
    [ObservableProperty]
    private bool _IsPinned;

    public MobileStatusSubject BasicStatus { get; }
    public MobileRemodeledStatusSubject RemodeledStatus { get; }

    #endregion

    #region Entity relationships

    [ObservableProperty, NotifyPropertyChangedFor(nameof(CategoryIcon))]
    private Category? _Category;
    [ObservableProperty, Required]
    private Serial? _Serial;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(IsPairable))]
    private MobileKind? _Kind;
    [ObservableProperty, Required]
    private Role? _Role;
    [ObservableProperty, Required]
    private Position? _DefaultPosition;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(InitialGradeText)), NotifyPropertyChangedFor(nameof(InitialGradeColor))]
    private Grade? _InitialGrade;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(TerrainText))]
    private Terrain? _Terrain1;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(TerrainText))]
    private Terrain? _Terrain2;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(TerrainText))]
    private Terrain? _Terrain3;
    [ObservableProperty, Required, NotifyPropertyChangedFor(nameof(GradeText)), NotifyPropertyChangedFor(nameof(GradeColor))]
    private Grade? _Grade;
    [ObservableProperty, Required]
    private AceImpl? _HasAce;
    [ObservableProperty]
    private MobileSSkill? _SSkill1;
    [ObservableProperty]
    private MobileSSkill? _SSkill2;

    public GwObservableCollection<Serial> SubSerials { get; }

    #endregion

    #region Extensions

    public string CategoryIcon => Category?.Icon ?? GwIcon.Unknown;
    public string InitialGradeText => InitialGrade?.Name ?? string.Empty;
    public string InitialGradeColor => InitialGrade?.Color ?? "White";
    public string TerrainText => $"{Terrain1?.Name}{Terrain2?.Name}{Terrain3?.Name}";
    public string GradeText => Grade?.Name ?? string.Empty;
    public string GradeColor => Grade?.Color ?? "White";
    public bool HasMemo => !string.IsNullOrEmpty(Memo);
    public bool IsPairable => Kind?.Type == MobileKindType.Change || Kind?.Type == MobileKindType.Combi;

    [ObservableProperty]
    private string _SubSerialsText = "";
    [ObservableProperty]
    private string _TagsText = "";

    public MobileStatusSubject BoostStatus { get; }
    public MobileStatusSubject ActualStatus { get; }

    #endregion


    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        SetJoinedSubSerials();
        SetJoinedTags();
        CalculateCuspaBoost();
        CalculateSupportBoost();
        CalculateCoMobileBoost();
        CalculatePilotBoost();
        CalculateBoostStatus();
        CalculateActualStatus();
    }

    partial void OnKindChanged(MobileKind? value)
    {
        if (!IsPairable)
        {
            PairId = null;
            Pair = null;
        }
    }

    #region Pair

    [ObservableProperty]
    private int? _PairId;
    [ObservableProperty]
    private MobileSubject? _Pair;
    private IDisposable? pairSupportChangedHandler = null;

    partial void OnPairChanged(MobileSubject? value)
    {
        pairSupportChangedHandler?.Dispose();
        pairSupportChangedHandler = null;
        pairSupportChangedHandler = value?.PropertyChanged.Where(n => n == "PairBoost").Subscribe(WhenPairChanged).AddTo(Disposables);
        WhenPairChanged();
    }

    private void WhenPairChanged(string? _ = "")
    {
        if (!IsIdle) return;
        CalculateSupportBoost();
        CalculatePilotBoost();
        CalculateBoostStatus();
        CalculateActualStatus();
    }

    private void RaisePairBoostChanged() =>
        OnPropertyChanged("PairBoost");

    #endregion

    #region Pilot

    [ObservableProperty]
    private Pilot? _Pilot;
    private IDisposable? pilotChangedHandler = null;

    partial void OnPilotChanged(Pilot? value)
    {
        pilotChangedHandler?.Dispose();
        pilotChangedHandler = null;
        pilotChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenPilotChanged).AddTo(Disposables);
        WhenPilotChanged();
    }

    // 機体ステータスの割合計算があるので最後
    public MobileStatusSubject PilotBoost { get; }

    private void WhenPilotChanged(string? _ = "")
    {
        if (!IsIdle) return;
        CalculatePilotBoost();
        CalculateBoostStatus();
        CalculateActualStatus();
    }

    private void CalculatePilotBoost()
    {
        PilotBoost.Reset();
        if (Pilot == null) return;

        var withoutPilot = new MobileStatusSubject().Add(BasicStatus).Add(RemodeledStatus).Add(CuspaBoost).Add(SupportBoost).Add(CoMobileBoost);

        Dictionary<MobileStatusType, decimal> boostBases = new()
        {
            { MobileStatusType.Hp,              withoutPilot.Hp },
            { MobileStatusType.BeamAttack,      withoutPilot.BeamAttack },
            { MobileStatusType.PhysicalAttack,  withoutPilot.PhysicalAttack },
            { MobileStatusType.BeamDefence,     withoutPilot.BeamDefence },
            { MobileStatusType.PhysicalDefence, withoutPilot.PhysicalDefence },
            { MobileStatusType.CriticalRate,    withoutPilot.CriticalRate },
            { MobileStatusType.CriticalDamage,  withoutPilot.CriticalDamage },
            { MobileStatusType.Mobility,        withoutPilot.Mobility },
            { MobileStatusType.SuperEnRecovery, withoutPilot.SuperEnRecovery },
            { MobileStatusType.AceEnRecovery,   withoutPilot.AceEnRecovery },
        };

        foreach (var ability in Pilot.AbilitiesForMobile)
        {
            if (ability.Calc == CalcMethodType.Addition)
            {
                foreach (var type in ability.Boost.ToMobileStatusTypes())
                {
                    boostBases[type] += ability.Value;
                }
            }
            else if (ability.Calc == CalcMethodType.Multiplication)
            {
                foreach (var type in ability.Boost.ToMobileStatusTypes())
                {
                    boostBases[type] += boostBases[type] * ability.Value;
                }
            }
        }

        foreach (var boostBase in boostBases)
        {
            PilotBoost.Add(boostBase.Key, decimal.ToInt32(boostBase.Value) - withoutPilot.Get(boostBase.Key));
        }
    }

    #endregion

    #region Cuspa, S-Cuspa

    [ObservableProperty]
    private CuspaSubject? _Cuspa1;
    private IDisposable? cuspa1ChangedHandler = null;

    partial void OnCuspa1Changed(CuspaSubject? value)
    {
        cuspa1ChangedHandler?.Dispose();
        cuspa1ChangedHandler = null;
        cuspa1ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _Cuspa2;
    private IDisposable? cuspa2ChangedHandler = null;

    partial void OnCuspa2Changed(CuspaSubject? value)
    {
        cuspa2ChangedHandler?.Dispose();
        cuspa2ChangedHandler = null;
        cuspa2ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _Cuspa3;
    private IDisposable? cuspa3ChangedHandler = null;

    partial void OnCuspa3Changed(CuspaSubject? value)
    {
        cuspa3ChangedHandler?.Dispose();
        cuspa3ChangedHandler = null;
        cuspa3ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _Cuspa4;
    private IDisposable? cuspa4ChangedHandler = null;

    partial void OnCuspa4Changed(CuspaSubject? value)
    {
        cuspa4ChangedHandler?.Dispose();
        cuspa4ChangedHandler = null;
        cuspa4ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _Cuspa5;
    private IDisposable? cuspa5ChangedHandler = null;

    partial void OnCuspa5Changed(CuspaSubject? value)
    {
        cuspa5ChangedHandler?.Dispose();
        cuspa5ChangedHandler = null;
        cuspa5ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _Cuspa6;
    private IDisposable? cuspa6ChangedHandler = null;

    partial void OnCuspa6Changed(CuspaSubject? value)
    {
        cuspa6ChangedHandler?.Dispose();
        cuspa6ChangedHandler = null;
        cuspa6ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _SCuspa1;
    private IDisposable? sCuspa1ChangedHandler = null;

    partial void OnSCuspa1Changed(CuspaSubject? value)
    {
        sCuspa1ChangedHandler?.Dispose();
        sCuspa1ChangedHandler = null;
        sCuspa1ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _SCuspa2;
    private IDisposable? sCuspa2ChangedHandler = null;

    partial void OnSCuspa2Changed(CuspaSubject? value)
    {
        sCuspa2ChangedHandler?.Dispose();
        sCuspa2ChangedHandler = null;
        sCuspa2ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _SCuspa3;
    private IDisposable? sCuspa3ChangedHandler = null;

    partial void OnSCuspa3Changed(CuspaSubject? value)
    {
        sCuspa3ChangedHandler?.Dispose();
        sCuspa3ChangedHandler = null;
        sCuspa3ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    [ObservableProperty]
    private CuspaSubject? _SCuspa4;
    private IDisposable? sCuspa4ChangedHandler = null;

    partial void OnSCuspa4Changed(CuspaSubject? value)
    {
        sCuspa4ChangedHandler?.Dispose();
        sCuspa4ChangedHandler = null;
        sCuspa4ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCuspaChanged).AddTo(Disposables);
        WhenCuspaChanged();
    }

    public CuspaStatusSubject CuspaBoost { get; }

    private void WhenCuspaChanged(string? _ = "")
    {
        if (!IsIdle) return;
        CalculateCuspaBoost();
        CalculatePilotBoost();
        CalculateBoostStatus();
        CalculateActualStatus();
    }

    private void CalculateCuspaBoost(CuspaSubject? cuspa)
    {
        if (cuspa == null) return;
        CuspaBoost.Add(cuspa.ActualStatus);
    }

    private void CalculateSCuspaBoost(CuspaSubject? cuspa)
    {
        if (cuspa == null) return;
        var multiplier = multipliers.FirstOrDefault(m => m.Item1 == Role?.Type && m.Item2 == cuspa.Kind?.Type)?.Item3 ?? 1;
        CuspaBoost.AddWithBonus(cuspa.ActualStatus, multiplier);
    }

    private void CalculateCuspaBoost()
    {
        CuspaBoost.Reset();
        CalculateCuspaBoost(Cuspa1);
        CalculateCuspaBoost(Cuspa2);
        CalculateCuspaBoost(Cuspa3);
        CalculateCuspaBoost(Cuspa4);
        CalculateCuspaBoost(Cuspa5);
        CalculateCuspaBoost(Cuspa6);
        CalculateSCuspaBoost(SCuspa1);
        CalculateSCuspaBoost(SCuspa2);
        CalculateSCuspaBoost(SCuspa3);
        CalculateSCuspaBoost(SCuspa4);
    }

    private static readonly List<Tuple<RoleType, CuspaKindType, decimal>> multipliers =
    [
        Tuple.Create(RoleType.Defensive, CuspaKindType.SHp, 2M),
        Tuple.Create(RoleType.Defensive, CuspaKindType.SBeamDefence, 2.5M),
        Tuple.Create(RoleType.Defensive, CuspaKindType.SPhysicalDefence, 2.5M),
        Tuple.Create(RoleType.Offensive, CuspaKindType.SBeamAttack, 3M),
        Tuple.Create(RoleType.Offensive, CuspaKindType.SPhysicalAttack, 3M),
        Tuple.Create(RoleType.Support, CuspaKindType.SHp, 2M),
        Tuple.Create(RoleType.Support, CuspaKindType.SBeamDefence, 2M),
        Tuple.Create(RoleType.Support, CuspaKindType.SPhysicalDefence, 2M),
        Tuple.Create(RoleType.Support, CuspaKindType.SMobility, 2M),
        Tuple.Create(RoleType.Recovery, CuspaKindType.SHp, 3M),
        Tuple.Create(RoleType.Recovery, CuspaKindType.SBeamDefence, 2M),
        Tuple.Create(RoleType.Recovery, CuspaKindType.SPhysicalDefence, 2M),
        Tuple.Create(RoleType.Disruptive, CuspaKindType.SHp, 2M),
        Tuple.Create(RoleType.Disruptive, CuspaKindType.SMobility, 3M),
        Tuple.Create(RoleType.Disruptive, CuspaKindType.SBeamDefence, 1.5M),
        Tuple.Create(RoleType.Disruptive, CuspaKindType.SPhysicalDefence, 1.5M),
        Tuple.Create(RoleType.AllRounder, CuspaKindType.SHp, 2M),
        Tuple.Create(RoleType.AllRounder, CuspaKindType.SBeamAttack, 1.5M),
        Tuple.Create(RoleType.AllRounder, CuspaKindType.SPhysicalAttack, 1.5M),
        Tuple.Create(RoleType.AllRounder, CuspaKindType.SBeamDefence, 1.5M),
        Tuple.Create(RoleType.AllRounder, CuspaKindType.SPhysicalDefence, 1.5M),
        Tuple.Create(RoleType.AllRounder, CuspaKindType.SMobility, 2M),
    ];

    #endregion

    #region Support

    [ObservableProperty]
    private Support? _Support1;
    private IDisposable? support1ChangedHandler = null;

    partial void OnSupport1Changed(Support? value)
    {
        support1ChangedHandler?.Dispose();
        support1ChangedHandler = null;
        support1ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenSupportChanged).AddTo(Disposables);
        WhenSupportChanged();
    }

    [ObservableProperty]
    private Support? _Support2;
    private IDisposable? support2ChangedHandler = null;

    partial void OnSupport2Changed(Support? value)
    {
        support2ChangedHandler?.Dispose();
        support2ChangedHandler = null;
        support2ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenSupportChanged).AddTo(Disposables);
        WhenSupportChanged();
    }

    [ObservableProperty]
    private Support? _Support3;
    private IDisposable? support3ChangedHandler = null;

    partial void OnSupport3Changed(Support? value)
    {
        support3ChangedHandler?.Dispose();
        support3ChangedHandler = null;
        support3ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenSupportChanged).AddTo(Disposables);
        WhenSupportChanged();
    }

    [ObservableProperty]
    private Support? _Support4;
    private IDisposable? support4ChangedHandler = null;

    partial void OnSupport4Changed(Support? value)
    {
        support4ChangedHandler?.Dispose();
        support4ChangedHandler = null;
        support4ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenSupportChanged).AddTo(Disposables);
        WhenSupportChanged();
    }

    public SupportStatus SupportBoost { get; }
    public SupportStatus SupportBoostOwn { get; }

    private void WhenSupportChanged(string? _ = "")
    {
        if (!IsIdle) return;
        CalculateSupportBoost();
        CalculatePilotBoost();
        CalculateBoostStatus();
        CalculateActualStatus();
        // Pair 購読用
        RaisePairBoostChanged();
    }

    private void CalculateSupportBoostOwn(Support? support)
    {
        if (support == null) return;
        SupportBoostOwn.Add(support.ActualStatus);
    }

    private void CalculateSupportBoost()
    {
        SupportBoostOwn.Reset();
        CalculateSupportBoostOwn(Support1);
        CalculateSupportBoostOwn(Support2);
        CalculateSupportBoostOwn(Support3);
        CalculateSupportBoostOwn(Support4);
        SupportBoost.Reset();
        SupportBoost.Add(SupportBoostOwn);
        if (Pair != null)
        {
            SupportBoost.Add(Pair.SupportBoostOwn);
        }
    }

    #endregion

    #region CoMobile

    [ObservableProperty]
    private CoMobileSubject? _CoMobile1;
    private IDisposable? CoMobile1ChangedHandler = null;

    partial void OnCoMobile1Changed(CoMobileSubject? value)
    {
        CoMobile1ChangedHandler?.Dispose();
        CoMobile1ChangedHandler = null;
        CoMobile1ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCoMobileChanged).AddTo(Disposables);
        WhenCoMobileChanged();
    }

    [ObservableProperty]
    private CoMobileSubject? _CoMobile2;
    private IDisposable? CoMobile2ChangedHandler = null;

    partial void OnCoMobile2Changed(CoMobileSubject? value)
    {
        CoMobile2ChangedHandler?.Dispose();
        CoMobile2ChangedHandler = null;
        CoMobile2ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCoMobileChanged).AddTo(Disposables);
        WhenCoMobileChanged();
    }

    [ObservableProperty]
    private CoMobileSubject? _CoMobile3;
    private IDisposable? CoMobile3ChangedHandler = null;

    partial void OnCoMobile3Changed(CoMobileSubject? value)
    {
        CoMobile3ChangedHandler?.Dispose();
        CoMobile3ChangedHandler = null;
        CoMobile3ChangedHandler = value?.PropertyChanged.Where(n => n == "MobileBoost").Subscribe(WhenCoMobileChanged).AddTo(Disposables);
        WhenCoMobileChanged();
    }

    public CoMobileStatusSubject CoMobileBoost { get; }

    private void WhenCoMobileChanged(string? _ = "")
    {
        if (!IsIdle) return;
        CalculateCoMobileBoost();
        CalculatePilotBoost();
        CalculateBoostStatus();
        CalculateActualStatus();
    }

    private void CalculateCoMobileBoost(CoMobileSubject? CoMobile)
    {
        if (CoMobile == null) return;
        if (Role != null && Role.Type == CoMobile.Role?.Type)
        {
            CoMobileBoost.AddWithBonus(CoMobile.ActualStatus, (decimal)1.1);
        }
        else
        {
            CoMobileBoost.Add(CoMobile.ActualStatus);
        }
    }

    private void CalculateCoMobileBoost()
    {
        CoMobileBoost.Reset();
        CalculateCoMobileBoost(CoMobile1);
        CalculateCoMobileBoost(CoMobile2);
        CalculateCoMobileBoost(CoMobile3);
    }

    #endregion

    private void WhenBasicStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateActualStatus();
    }

    private void WhenRemodeledStatusChanged(string? _)
    {
        if (!IsIdle) return;
        CalculateBoostStatus();
        CalculateActualStatus();
    }

    private void WhenSubSerialsChanged(NotifyCollectionChangedEventArgs _)
    {
        if (!IsIdle) return;
        SetJoinedSubSerials();
    }

    private void CalculateBoostStatus() =>
        BoostStatus.Reset().Add(RemodeledStatus).Add(PilotBoost).Add(CuspaBoost).Add(SupportBoost).Add(CoMobileBoost);

    private void CalculateActualStatus() =>
        ActualStatus.Set(BasicStatus).Add(BoostStatus);

    private void SetJoinedSubSerials() =>
        SubSerialsText = string.Join(", ", SubSerials.OrderBy(i => i.Order).Select(i => i.Name));

}
