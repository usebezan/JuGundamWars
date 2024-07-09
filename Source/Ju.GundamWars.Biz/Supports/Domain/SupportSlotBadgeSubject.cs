using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Core;
using Ju.GundamWars.Core.Ju.GundamWars.Masters.Boosts;
using Ju.GundamWars.Core.Ju.GundamWars.System;
using Ju.GundamWars.Mobiles.Domain;
using Ju.GundamWars.Supports.Domain;
using Ju.GundamWars.Supports.Domain.Entities;

namespace Ju.GundamWars.Domain.Supports;

public partial class SupportSlotBadgeSubject : GwObservableValidator
{

    public SupportSlotBadgeSubject()
    {
        SupportStatusType = SupportStatusType.Unknown;
        MobileStatusTypes = null;
        StatusValue = 0;

        isIdle = true;
    }


    private bool isIdle;

    #region Entity fields

    [ObservableProperty]
    private byte _Seq;

    #endregion

    #region Entity relationships

    [ObservableProperty]
    private SupportSubject? _Support;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(SlotName)), NotifyPropertyChangedFor(nameof(BadgeName)), NotifyPropertyChangedFor(nameof(IsBonused))]
    private SupportSlot? _Slot;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BadgeName)), NotifyPropertyChangedFor(nameof(IsBonused))]
    private SupportBadge? _Badge;

    #endregion

    #region Extensions

    public string SlotName => Slot?.Name ?? GwText.Unknown;
    public string BadgeName => Slot?.IsAttachable ?? false ? Badge?.Name ?? string.Empty : "---";
    public bool IsBonused => (Slot?.IsBonusable ?? false) && Badge != null && Slot.Boost.IsSameStatus(Badge.Boost);

    public BoostUnitType BoostUnitType { get; private set; }
    public SupportStatusType SupportStatusType { get; private set; }
    public MobileStatusType[]? MobileStatusTypes { get; private set; }
    public int StatusValue { get; private set; }

    #endregion


    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        CalculateStatus();
    }

    private void Suspend(Action invoker)
    {
        isIdle = false;
        invoker();
        isIdle = true;
    }

    partial void OnSlotChanged(SupportSlot? value)
    {
        if (!isIdle) return;
        // そのままだと OnBadgeChanged() が発火し、CalculateStatus() を二重コールするため Suspend()
        Suspend(() =>
        {
            if (!(Slot?.IsAttachable ?? false))
            {
                Badge = null;
            }
        });
        CalculateStatus();
    }

    partial void OnBadgeChanged(SupportBadge? value)
    {
        if (!isIdle) return;
        CalculateStatus();
    }

    private void CalculateStatus()
    {
        BoostUnitType = Slot?.Boost.ToBoostUnitType() ?? BoostUnitType.Unknown;
        SupportStatusType = SupportStatusType.Unknown;
        MobileStatusTypes = null;
        StatusValue = 0;
        if (Slot != null)
        {
            if (BoostUnitType == BoostUnitType.Mobile)
            {
                SupportStatusType = Slot.Boost.ToSupportStatusType();
                MobileStatusTypes = Slot.Boost.ToMobileStatusTypes();
                StatusValue = decimal.ToInt32(Slot.Value);
            }
            else if (BoostUnitType == BoostUnitType.Badge && Badge != null)
            {
                SupportStatusType = Badge.Boost.ToSupportStatusType();
                MobileStatusTypes = Badge.Boost.ToMobileStatusTypes();
                if (Badge.Calc == CalcType.Addition)
                {
                    StatusValue = decimal.ToInt32(Badge.Value);
                }
                else if (Badge.Calc == CalcType.Multiplication)
                {
                    StatusValue = 100.Multiply(Badge.Value);
                }
                if (Slot.Boost.IsSameStatus(Badge.Boost))
                {
                    // 必殺バッジ系は必殺回復のみ加算の設定になっている
                    if (Slot.Calc == CalcType.Addition)
                    {
                        StatusValue += decimal.ToInt32(Slot.Value);
                    }
                    else if (Slot.Calc == CalcType.Multiplication)
                    {
                        StatusValue += StatusValue.Multiply(Slot.Value);
                    }
                }
            }
        }
        // SupportSubject で購読
        OnPropertyChanged("Status");
    }

}
