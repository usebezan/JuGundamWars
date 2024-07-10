using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.BizMaster;
using Ju.GundamWars.BizMaster.Boosts.Domain;
using Ju.GundamWars.BizMaster.SupportBadges.Domain.Model;
using Ju.GundamWars.BizMaster.SupportSlots.Domain;
using Ju.GundamWars.BizMaster.SupportSlots.Domain.Model;
using Ju.GundamWars.BizMaster.SupportStatuses.Domain;
using Ju.GundamWars.Commons.Domain.Model;

namespace Ju.GundamWars.Biz.Supports.Domain.Model;

public partial class SupportSlotBadge : ModelBase
{

    public SupportSlotBadge()
    {
        SupportStatusType = SupportStatusType.Unknown;
        StatusValue = 0;

        isIdle = true;
    }


    private bool isIdle;

    #region Primitives

    [ObservableProperty]
    private byte _Seq;

    #endregion

    #region Navigations

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SlotName)), NotifyPropertyChangedFor(nameof(BadgeName)), NotifyPropertyChangedFor(nameof(IsBonused))]
    private SupportSlot? _Slot;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BadgeName)), NotifyPropertyChangedFor(nameof(IsBonused))]
    private SupportBadge? _Badge;

    #endregion

    #region Extensions

    public string SlotName => Slot?.Name ?? GwText.None;
    public string BadgeName => Slot?.IsAttachable ?? false ? Badge?.Name ?? string.Empty : "---";
    public bool IsBonused => Slot != null && Slot.IsBonusable && Badge != null && Slot.BoostStatus == Badge.BoostStatus;

    #endregion

    public SupportStatusType SupportStatusType { get; private set; }
    public int StatusValue { get; private set; }


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
        if (!(Slot?.IsAttachable ?? false))
        {
            // そのままだと OnBadgeChanged() が発火し、CalculateStatus() を二重コールするため Suspend()
            Suspend(() =>
            {
                Badge = null;
            });
        }
        CalculateStatus();
    }

    partial void OnBadgeChanged(SupportBadge? value)
    {
        if (!isIdle) return;
        CalculateStatus();
    }

    // 計算は SupportSlotKindType で判断する
    // BoostCategoryType は SupportSlotKindType から固定で設定している
    private void CalculateStatus()
    {
        SupportStatusType = SupportStatusType.Unknown;
        StatusValue = 0;
        if (Slot != null)
        {
            if (Slot.Kind == SupportSlotKindType.Normal && Badge != null)
            {
                // 通常スロットはバッジの値を機体へ
                SupportStatusType = Badge.BoostStatus.ToSupportStatusType();
                StatusValue = Badge.CalcBoostedValue();
            }
            else if (Slot.Kind == SupportSlotKindType.Unlock)
            {
                // 解放スロットはスロットの値を機体へ
                SupportStatusType = Slot.BoostStatus.ToSupportStatusType();
                StatusValue = Slot.CalcBoostedValue();
            }
            else if (Slot.Kind == SupportSlotKindType.Bonus && Badge != null)
            {
                // ボーナス スロットはバッジの値を機体へ
                SupportStatusType = Badge.BoostStatus.ToSupportStatusType();
                StatusValue = Badge.CalcBoostedValue();
                if (IsBonused)
                {
                    // ボーナス適用の場合はバッジの値とスロットの値を掛けて加算
                    StatusValue += Slot.CalcBoostedValue(StatusValue);
                }
            }
        }
        // SupportSubject で購読
        OnPropertyChanged("Status");
    }

}
