using CommunityToolkit.Mvvm.ComponentModel;
using Ju.GundamWars.Client.SupportBadges.Domain;
using Ju.GundamWars.Client.SupportSlots.Domain;
using Ju.GundamWars.Commons.Domain.Model;
using Ju.GundamWars.Share.Boosts.Domain;
using Ju.GundamWars.Share.Supports.Domain;
using Ju.GundamWars.Share.SupportSlots.Domain;

namespace Ju.GundamWars.Client.Supports.Domain;

public partial class SupportSlotBadge : ModelBase, ISupportSlotBadge
{

    public SupportSlotBadge()
    {
        BoostStatusType = BoostStatusType.Unknown;
        StatusValue = 0;

        isIdle = true;
    }


    private bool isIdle;

    #region Primitives

    [ObservableProperty]
    private int _SupportId;
    [ObservableProperty]
    private byte _Seq;
    [ObservableProperty]
    private int _SupportSlotId;
    [ObservableProperty]
    private int? _SupportBadgeId;

    #endregion

    #region Navigations

    [ObservableProperty, NotifyPropertyChangedFor(nameof(SlotName)), NotifyPropertyChangedFor(nameof(BadgeName)), NotifyPropertyChangedFor(nameof(IsBonused))]
    private SupportSlot? _SupportSlot;
    [ObservableProperty, NotifyPropertyChangedFor(nameof(BadgeName)), NotifyPropertyChangedFor(nameof(IsBonused))]
    private SupportBadge? _SupportBadge;

    #endregion

    #region Extensions

    public string SlotName => SupportSlot?.Name ?? GwText.None;
    public string BadgeName => (SupportSlot != null && SupportSlot.IsAttachable) ? SupportBadge?.Name ?? string.Empty : "---";
    public bool IsBonused => SupportSlot != null && SupportSlot.IsBonusable && SupportBadge != null && SupportSlot.BoostStatusType == SupportBadge.BoostStatusType;

    #endregion

    public BoostStatusType BoostStatusType { get; private set; }
    public int StatusValue { get; private set; }


    partial void OnSupportSlotChanged(SupportSlot? value)
    {
        SupportSlotId = SupportSlot?.Id ?? 0;
        if (!isIdle) return;
        if (!(SupportSlot != null && SupportSlot.IsAttachable))
        {
            // そのままだと OnBadgeChanged() が発火し、CalculateStatus() を二重コールするため Suspend()
            Suspend(() =>
            {
                SupportBadge = null;
            });
        }
        CalculateStatus();
    }

    partial void OnSupportBadgeChanged(SupportBadge? value)
    {
        SupportBadgeId = SupportBadge?.Id;
        if (!isIdle) return;
        CalculateStatus();
    }

    // 計算は SupportSlotKindType で判断する
    // BoostCategoryType は SupportSlotKindType から固定で設定している
    private void CalculateStatus()
    {
        BoostStatusType = BoostStatusType.Unknown;
        StatusValue = 0;
        if (SupportSlot != null)
        {
            if (SupportSlot.SupportSlotKindType == SupportSlotKindType.Normal && SupportBadge != null)
            {
                // 通常スロットはバッジの値を機体へ
                BoostStatusType = SupportBadge.BoostStatusType;
                StatusValue = SupportBadge.CalcBoostedValue();
            }
            else if (SupportSlot.SupportSlotKindType == SupportSlotKindType.Unlock)
            {
                // 解放スロットはスロットの値を機体へ
                BoostStatusType = SupportSlot.BoostStatusType;
                StatusValue = SupportSlot.CalcBoostedValue();
            }
            else if (SupportSlot.SupportSlotKindType == SupportSlotKindType.Bonus && SupportBadge != null)
            {
                // ボーナス スロットはバッジの値を機体へ
                BoostStatusType = SupportBadge.BoostStatusType;
                StatusValue = SupportBadge.CalcBoostedValue();
                if (IsBonused)
                {
                    // ボーナス適用の場合はバッジの値とスロットの値を掛けて加算
                    StatusValue += SupportSlot.CalcBoostedValue(StatusValue);
                }
            }
        }
        // Support で購読
        OnPropertyChanged("SlotBadge");
    }

    private void Suspend(Action invoker)
    {
        isIdle = false;
        invoker();
        isIdle = true;
    }

    public void Initialize(Action initializer)
    {
        Suspend(initializer);
        CalculateStatus();
    }

}
